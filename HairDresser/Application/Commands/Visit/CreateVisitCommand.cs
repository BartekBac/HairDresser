using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Visit
{
    public class CreateVisitCommand : IRequest
    {
        public string ClientId { get; set; }
        public string WorkerId { get; set; }
        public string[] ServiceIds { get; set; }
        public DateTime Term { get; set; }
        public int TotalTime { get; set; }
        public float TotalPrice { get; set; }
    }
}
