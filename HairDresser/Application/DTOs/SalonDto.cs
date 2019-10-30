using Domain.Enums;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    public class SalonDto
    {
        public string Name { get; set; }
        public AddressDto Address { get; set; }
        public string AdditionalInfo { get; set; }
        public SalonType Type { get; set; }
        public ScheduleDto Schedule { get; set; }
        public UserDto Admin { get; set; }
        public string ImageSource { get; set; }
        public IEnumerable<WorkerDto> Workers { get; set; }
    }
}
