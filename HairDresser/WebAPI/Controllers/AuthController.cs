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
        IUserService _userService;
        IJWTFactory _jwtService;
        IClientService _clientService;
        ISalonService _salonService;
        public AuthController(UserManager<IdentityUser> userManager,
                              IUserService userService,
                              IJWTFactory jwtService,
                              IClientService clientService,
                              ISalonService salonService)
        {
            _userManager = userManager;
            _userService = userService;
            _jwtService = jwtService;
            _clientService = clientService;
            _salonService = salonService;
        }

        [HttpPost("register/client")]
        public async Task<IActionResult> RegisterClient(ClientCreationDto clientCreation)
        {
            try
            {
                var user = await _userService.CreateUserAsync(clientCreation.UserData);
                var identityUser = await _userManager.FindByIdAsync(user.Id);
                _clientService.CreateClient(clientCreation, identityUser);
                var response = new LoginResponse
                {
                    Id = user.Id,
                    Token = null,
                    Role = clientCreation.UserData.Role
                };
                return Ok(response);
            }
            catch(Exception e)
            {
                return BadRequest("Register Failed. " + e.Message);
            }
        }

        [HttpPost("register/salon")]
        public async Task<IActionResult> RegisterSalon(SalonCreationDto salonCreation)
        {
            try
            {
                var user = await _userService.CreateUserAsync(salonCreation.UserData);
                var identityUser = await _userManager.FindByIdAsync(user.Id);
                _salonService.CreateSalon(salonCreation, identityUser);
                var response = new LoginResponse
                {
                    Id = user.Id,
                    Token = null,
                    Role = salonCreation.UserData.Role
                };
                return Ok(response);
            }
            catch (Exception e)
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
