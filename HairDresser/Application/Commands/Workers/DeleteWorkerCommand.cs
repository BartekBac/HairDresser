using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Workers
{
    public class DeleteWorkerCommand : IRequest
    {
        public string Id { get; set; }
    }
}
