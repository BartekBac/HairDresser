using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands
{
    public class UpdateScheduleCommand : IRequest
    {
        public string Id { get; set; }
        public ScheduleDto Schedule { get; set; }
    }
}
