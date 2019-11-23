using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Visit
{
    public class RejectVisitCommand : IRequest<VisitDto>
    {
        public string Id { get; set; }
        public bool IsWorkerRejecting { get; set; }
    }
}
