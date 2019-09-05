using System;
using System.Collections.Generic;
using System.Text;
using Application.DTOs;
using Microsoft.AspNetCore.Identity;

namespace Application.Services
{
    public interface IUserService
    {
        SalonDto CreateSalon(SalonCreationDto salonCreation, IdentityUser admin);
    }
}
