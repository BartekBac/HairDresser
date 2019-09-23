using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Authentication
{
    public class LoginResponse
    {
        public string Id { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
    }
}
