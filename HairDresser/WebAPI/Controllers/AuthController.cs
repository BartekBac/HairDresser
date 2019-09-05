using Application.DTOs;
using Application.Services;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/")]
    public class AuthController : Controller
    {
        UserManager<IdentityUser> _userManager;
        RoleManager<IdentityRole> _roleManager;
        IMapper _mapper;
        IUserService _userService;

        public AuthController(UserManager<IdentityUser> userManager,
                              RoleManager<IdentityRole> roleManager,
                              IMapper mapper,
                              IUserService userService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _userService = userService;
        }
        [HttpPost("register-salon")]
        public async Task<IActionResult> CreateSalonAsync(SalonCreationDto salonCreation)
        {
            var user = _mapper.Map<IdentityUser>(salonCreation.userCreation);

            IdentityResult result = await _userManager.CreateAsync(user, salonCreation.userCreation.Password);
            if (!result.Succeeded)
            {
                var errorMessage = "Failed. Cannot create user.";
                foreach(var msg in result.Errors.ToArray())
                {
                    errorMessage += " [" + msg.Code + "] " + msg.Description;
                }

                return BadRequest(errorMessage);
            }

            result = await _userManager.AddToRoleAsync(user, "salon");
            if (!result.Succeeded)
            {
                var errorMessage = "Failed. Cannot grant salon role.";
                foreach (var msg in result.Errors.ToArray())
                {
                    errorMessage += " [" + msg.Code + "] " + msg.Description;
                }

                return BadRequest(errorMessage);
            }

            return Created("register-salon", _userService.CreateSalon(salonCreation, user));
        }
    }
}
