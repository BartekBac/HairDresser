
using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Services
{
    public class CreateServiceCommand : IRequest<ServiceDto>
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public int Time { get; set; }
        public string SalonId { get; set; }
    }
}
