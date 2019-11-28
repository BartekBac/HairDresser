using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Opinion
{
    public class DeleteOpinionCommand : IRequest
    {
        public string Id { get; set; }
    }
}
