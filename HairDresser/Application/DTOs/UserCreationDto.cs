using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    public class UserCreationDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
