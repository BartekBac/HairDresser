using Domain.Enums;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    public class SalonCreationDto
    {
        public string Name { get; set; }
        public string AdditionalInfo { get; set; }
        public SalonType Type { get; set; }
        public AddressDto Address { get; set; }
        public ScheduleDto Schedule { get; set; }
        public UserCreationDto UserData { get; set; }

    }
}
