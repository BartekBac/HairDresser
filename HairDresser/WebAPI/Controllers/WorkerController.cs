﻿using Application.Commands;
using Application.Commands.Workers;
using Application.DTOs;
using Application.Services;
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
    [Route("api/worker")]
    public class WorkerController : Controller
    {
        IMediator _mediator;
        IUserService _userService;
        public WorkerController(IMediator mediator, IUserService userService)
        {
            _mediator = mediator;
            _userService = userService;
        }

        [Authorize(Roles = RoleString.Salon)]
        [HttpPost]
        public async Task<IActionResult> CreateWorker([FromBody] CreateWorkerCommand command)
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

        [Authorize(Roles = RoleString.Salon)]
        [HttpPost("{id}/assign-services")]
        public async Task<IActionResult> AssignWorkerServices(string workerId, [FromBody] AssignWorkerServicesCommand command)
        {
            try
            {
                command.WorkerId = workerId;
                var result = await _mediator.Send(command);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize(Roles = RoleString.Salon+","+RoleString.Worker)]
        [HttpPut("{id}/update-image")]
        public async Task<IActionResult> UploadWorkerImage(string id, [FromBody] UploadImageCommand command)
        {
            try
            {
                command.Id = id;
                var result = await _mediator.Send(command);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize(Roles = RoleString.Salon + "," + RoleString.Worker)]
        [HttpPut("{id}")]
        public async Task<IActionResult> EditWorker(string id, [FromBody] WorkerDto worker)
        {
            try
            {
                var updateWorkerDataCommand = new UpdateWorkerDataCommand
                {
                   Id = id,
                   FirstName = worker.FirstName,
                   LastName = worker.LastName
                };
                var result = await _mediator.Send(updateWorkerDataCommand);
                var updateScheduleCommand = new UpdateScheduleCommand
                {
                    Id = id,
                    Schedule = worker.Schedule
                };
                result = await _mediator.Send(updateScheduleCommand);
                var uploadImageCommand = new UploadImageCommand
                {
                    Id = id,
                    ImageSource = worker.ImageSource
                };
                result = await _mediator.Send(uploadImageCommand);
                await _userService.UpdateUserAsync(id, worker.UserEmail, worker.UserPhoneNumber);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
