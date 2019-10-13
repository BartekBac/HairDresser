using Application.DTOs;
using Application.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Configurations;

namespace WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/client")]
    public class ClientController : Controller
    {
        UserManager<IdentityUser> _userManager;
        IClientService _clientService;

        public ClientController(UserManager<IdentityUser> userManager,
                              IClientService clientService)
        {
            _userManager = userManager;
            _clientService = clientService;
        }

        [Authorize(Roles = RoleString.Client)]
        [HttpPost]
        public async Task<IActionResult> CreateClientAsync(ClientCreationDto clientCreation)
        {

            IdentityUser user = await _userManager.FindByIdAsync(clientCreation.userId);

            if (user == null)
            {
                var errorMessage = "Failed. Cannot find user with given ID (" + clientCreation.userId + ")";
                return BadRequest(errorMessage);
            }

            try
            {
                var client = _clientService.CreateClient(clientCreation, user);
                return Created("Client", client);
            } 
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }

            
        }
    }
}
