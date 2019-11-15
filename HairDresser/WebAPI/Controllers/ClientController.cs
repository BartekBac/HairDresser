using Application.Commands.Client;
using Application.DTOs;
using Application.Queries.Client;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
        IMediator _mediator;

        public ClientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = RoleString.Client)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClientById(string id)
        {
            var result = await _mediator.Send(new GetClientByIdQuery { Id = id });
            return Ok(result);
        }

        [Authorize(Roles = RoleString.Client)]
        [HttpPost("{id}/add-salon")]
        public async Task<IActionResult> AddFavouriteSalon(string id, [FromBody] AddFavouriteSalonCommand command)
        {
            command.clientId = id;
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [Authorize(Roles = RoleString.Client)]
        [HttpPost("{id}/remove-salon")]
        public async Task<IActionResult> RemoveFavouriteSalon(string id, [FromBody] RemoveFavouriteSalonCommand command)
        {
            command.clientId = id;
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
