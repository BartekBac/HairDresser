using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Opinion
{
    public class UpdateOpinionAnswerCommand : IRequest
    {
        public string Id { get; set; }
        public string Answer { get; set; }
    }
}
