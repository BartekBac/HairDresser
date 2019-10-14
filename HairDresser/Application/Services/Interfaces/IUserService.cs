using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Microsoft.AspNetCore.Identity;

namespace Application.Services
{
    public interface IUserService
    {
       Task<UserDto> CreateUserAsync(UserCreationDto userCreation);
    }
}
