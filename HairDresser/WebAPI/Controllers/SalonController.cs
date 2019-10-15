﻿using Application.DTOs;
using Application.Queries.Salon;
using Application.Services;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("api/salon")]
    public class SalonController : Controller
    {
        private UserManager<IdentityUser> _userManager;
        private IMapper _mapper;
        private IMediator _mediator;
        private ISalonService _salonService;

        public SalonController(UserManager<IdentityUser> userManager,
                              IMapper mapper,
                              IMediator mediator,
                              ISalonService salonService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _mediator = mediator;
            _salonService = salonService;
        }

        [Authorize(Roles = RoleString.Salon)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSalonById(string id)
        {
            var result = await _mediator.Send(new GetSalonByIdQuery { Id = id });
            return Ok(result);
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
