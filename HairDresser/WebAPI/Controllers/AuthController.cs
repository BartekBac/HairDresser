using Application.DTOs;
using Application.Services;
using WebAPI.Authentication;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/auth")]
    [EnableCors("CorsPolicy")]
    public class AuthController : Controller
    {
        UserManager<IdentityUser> _userManager;
        RoleManager<IdentityRole> _roleManager;
        IMapper _mapper;
        IJWTFactory _jwtService;

        public AuthController(UserManager<IdentityUser> userManager,
                              RoleManager<IdentityRole> roleManager,
                              IMapper mapper,
                              IJWTFactory jwtService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _jwtService = jwtService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserCreationDto userCreation)
        {
            try
            {
                var user = _mapper.Map<IdentityUser>(userCreation);
                var roleIdentity = await _roleManager.FindByNameAsync(userCreation.Role);
                if (roleIdentity == null)
                {
                    return BadRequest("Register Failed. Given role does not exists.");
                }
                IdentityResult result = await _userManager.CreateAsync(user, userCreation.Password);
                if (!result.Succeeded)
                {
                    var errorMessage = "Register Failed. Cannot create user.";
                    foreach (var msg in result.Errors.ToArray())
                    {
                        errorMessage += " [" + msg.Code + "] " + msg.Description;
                    }

                    return BadRequest(errorMessage);
                }


                result = await _userManager.AddToRoleAsync(user, userCreation.Role);
                if (!result.Succeeded)
                {
                    var errorMessage = "Register Failed. Cannot grant " + userCreation.Role + " role.";
                    foreach (var msg in result.Errors.ToArray())
                    {
                        errorMessage += " [" + msg.Code + "] " + msg.Description;
                    }

                    return BadRequest(errorMessage);
                }
                var response = new LoginResponse
                {
                    Id = user.Id,
                    Token = null,
                    Role = userCreation.Role
                };
                return Ok(response);
            }
            catch(Exception e)
            {
                return BadRequest("Register Failed. " + e.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginCredential loginCredential)
        {
            var user = await _userManager.FindByNameAsync(loginCredential.UserName);

            if (user == null)
            {
                return NotFound();
            }

            if (!await _userManager.CheckPasswordAsync(user, loginCredential.Password))
            {
                return BadRequest("Wrong password.");
            }

            var roles = await _userManager.GetRolesAsync(user);

            if(roles.Count == 0)
            {
                return BadRequest("Account is not assigned to any role.");
            }

            if(roles.Count > 1)
            {
                return BadRequest("Account has to many roles.");
            }

            var userRole = roles.First();

            var jwtToken = _jwtService.GenerateToken(user, userRole);

            var response = new LoginResponse
            {
                Id = user.Id,
                Token = jwtToken,
                Role = userRole
            };

            return Ok(response);
        }
    }
}
