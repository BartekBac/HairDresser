using System;
using System.Collections.Generic;
using System.Text;
using Application.DTOs;
using Microsoft.AspNetCore.Identity;

namespace WebAPI.Authentication
{
    public interface IJWTFactory
    {
        string GenerateToken(IdentityUser user, string userRole);
    }
}
