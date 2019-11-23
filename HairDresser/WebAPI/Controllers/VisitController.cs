using Application.Commands.Visit;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
    [Route("api/visit")]
    public class VisitController : Controller
    {
        IMediator _mediator;
        public VisitController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = RoleString.Client)]
        [HttpPost]
        public async Task<IActionResult> CreateVisit([FromBody] CreateVisitCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize(Roles = RoleString.Client+","+RoleString.Worker)]
        [HttpPut("{id}/change-term")]
        public async Task<IActionResult> TermChangeRequest(string id, [FromBody] TermChangeRequestCommand command)
        {
            try
            {
                command.VisitId = id;
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize(Roles = RoleString.Client + "," + RoleString.Worker)]
        [HttpPut("{id}/reject")]
        public async Task<IActionResult> RejectVisit(string id, [FromBody] RejectVisitCommand command)
        {
            try
            {
                command.Id = id;
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize(Roles = RoleString.Client + "," + RoleString.Worker)]
        [HttpPut("{id}/confirm")]
        public async Task<IActionResult> ConfirmVisit(string id)
        {
            try
            {
                var command = new ConfirmVisitCommand { Id = id };
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
