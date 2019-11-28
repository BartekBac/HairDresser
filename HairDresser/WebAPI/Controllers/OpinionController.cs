using Application.Commands.Opinion;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebAPI.Configurations;

namespace WebAPI.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("api/opinion")]
    public class OpinionController : Controller
    {
        IMediator _mediator;
        public OpinionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = RoleString.Client)]
        [HttpPost]
        public async Task<IActionResult> CreateOpinion([FromBody] CreateOpinionCommand command)
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

        [Authorize(Roles = RoleString.Client)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOpinion(string id)
        {
            try
            {
                var command = new DeleteOpinionCommand
                {
                    Id = id
                };
                var result = await _mediator.Send(command);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
