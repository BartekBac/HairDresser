using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Opinion
{
    public class CreateOpinionCommand: IRequest<OpinionDto>
    {
        public string ClientId { get; set; }
        public string WorkerId { get; set; }
        public string Description { get; set; }
        public float Rate { get; set; }
        public string ImageSource { get; set; }
    }
}
