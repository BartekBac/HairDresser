using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands
{
    public class UploadImageCommand : IRequest
    {
        public Guid EntityId { get; set; }
        public string EntityType { get; set; }
        public string ImageSource { get; set; }
    }
}
