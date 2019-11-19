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
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
