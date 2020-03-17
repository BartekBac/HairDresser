using Application.DTOs;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands
{
    public class UpdateSalonDataCommand : IRequest
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public AddressDto Address { get; set; }
        public LocationDto Location { get; set; }
        public string AdditionalInfo { get; set; }
        public SalonType Type { get; set; }
    }
}
