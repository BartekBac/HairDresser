using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Services
{
    public class UpdateServiceCommand : IRequest
    {
        public string Id { get; set; }
        public string Name { get; private set; }
        public float Price { get; private set; }
        public int Time { get; private set; }
    }
}
