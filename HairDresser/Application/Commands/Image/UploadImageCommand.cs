using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands
{
    public class UploadImageCommand : IRequest
    {
        public string Id { get; set; }
        public string ImageSource { get; set; }
    }
}
