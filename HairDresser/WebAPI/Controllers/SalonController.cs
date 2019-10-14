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
    [Route("api/salon")]
    public class SalonController : Controller
    {
        UserManager<IdentityUser> _userManager;
        IMapper _mapper;
        ISalonService _salonService;

        public SalonController(UserManager<IdentityUser> userManager,
                              IMapper mapper,
                              ISalonService salonService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _salonService = salonService;
        }

        /*[Authorize(Roles = RoleString.Salon)]
        [HttpPost]
        public async Task<IActionResult> CreateSalonAsync(SalonCreationDto salonCreation)
        {
            //var user = _mapper.Map<IdentityUser>(salonCreation);

            IdentityUser user = await _userManager.FindByIdAsync(salonCreation.userId);

            if (user == null)
            {
                var errorMessage = "Failed. Cannot find user with given ID (" + salonCreation.userId + ")";
                return BadRequest(errorMessage);
            }

            try
            {
                var salon = _salonService.CreateSalon(salonCreation, user);
                return Created("salon", salon);
            } 
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }

            
        }*/
    }
}
