using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Services
{
    public class DeleteServiceCommand : IRequest
    {
        public string Id { get; set; }
    }
}
