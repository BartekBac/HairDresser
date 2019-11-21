using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Visit
{
    public class TermChangeRequestCommand : IRequest<VisitDto>
    {
        public string VisitId { get; set; }
        public bool IsWorkerRequesting { get; set; }
        public DateTime Term { get; set; }
    }
}
