using Domain.Enums;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    public class ClientCreationDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string userId { get; set; }

    }
}
