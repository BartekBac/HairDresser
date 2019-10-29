using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Workers
{
    public class CreateWorkerCommand : IRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserCreationDto UserData { get; set; }
        public string SalonId { get; set; } 
        public ScheduleDto Schedule { get; set; }
        public string ImageData { get; set; }
    }
}
