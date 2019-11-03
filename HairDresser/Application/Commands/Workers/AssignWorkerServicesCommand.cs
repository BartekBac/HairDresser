using System;
using System.Collections.Generic;
using System.Text;
using Application.DTOs;
using MediatR;

namespace Application.Commands.Workers
{
    public class AssignWorkerServicesCommand : IRequest
    {
        public string WorkerId { get; set; }
        public IEnumerable<ServiceDto> Services { get; set; }
    }
}
