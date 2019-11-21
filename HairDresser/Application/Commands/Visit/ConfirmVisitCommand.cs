using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Visit
{
    public class ConfirmVisitCommand : IRequest<VisitDto>
    {
        public string Id { get; set; }
    }
}
