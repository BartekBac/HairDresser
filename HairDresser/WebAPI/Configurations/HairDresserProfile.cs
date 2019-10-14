using Application.DTOs;
using AutoMapper;
using AutoMapper.Configuration;
using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Configurations
{
    public class HairDresserProfile: Profile
    {
        public HairDresserProfile()
        {
            CreateMap<UserCreationDto, IdentityUser>();
            CreateMap<IdentityUser, UserDto>();
            CreateMap<AddressDto, Address>();
            CreateMap<Address, AddressDto>();
            CreateMap<Client, ClientDto>();
            CreateMap<Salon, SalonDto>();
            //    .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address));
        }
    }
}
