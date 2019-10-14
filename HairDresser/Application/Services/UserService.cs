using Application.DTOs;
using AutoMapper;
using Domain.DbContexts;
using Domain.Entities;
using Domain.Exceptions;
using Domain.ValueObjects;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUserService
    {
        IMapper _mapper;
        UserManager<IdentityUser> _userManager;
        RoleManager<IdentityRole> _roleManager;

        public UserService(
            IMapper mapper,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<UserDto> CreateUserAsync(UserCreationDto userCreation)
        {
            var user = _mapper.Map<IdentityUser>(userCreation);
            var roleIdentity = _roleManager.FindByNameAsync(userCreation.Role);
            if (roleIdentity == null)
            {
                throw new ApplicationException("Register Failed. Given role does not exists.");
            }
            IdentityResult result = await _userManager.CreateAsync(user, userCreation.Password);
            if (!result.Succeeded)
            {
                var errorMessage = "Register Failed. Cannot create user.";
                foreach (var msg in result.Errors.ToArray())
                {
                    errorMessage += " [" + msg.Code + "] " + msg.Description;
                }

                throw new ApplicationException(errorMessage);
            }


            result = await _userManager.AddToRoleAsync(user, userCreation.Role);
            if (!result.Succeeded)
            {
                var errorMessage = "Register Failed. Cannot grant " + userCreation.Role + " role.";
                foreach (var msg in result.Errors.ToArray())
                {
                    errorMessage += " [" + msg.Code + "] " + msg.Description;
                }

                throw new ApplicationException(errorMessage);
            }

            return _mapper.Map<UserDto>(user);
        }
    }
}
