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
            CreateMap<Day, DayDto>()
                .ForMember(dest => dest.Begin.Hour, opt => opt.MapFrom(src => src.Begin.Hours))
                .ForMember(dest => dest.Begin.Minute, opt => opt.MapFrom(src => src.Begin.Minutes))
                .ForMember(dest => dest.End.Hour, opt => opt.MapFrom(src => src.End.Hours))
                .ForMember(dest => dest.End.Minute, opt => opt.MapFrom(src => src.End.Minutes));

            CreateMap<DayDto, Day>()
                .ForMember(dest => dest.Begin.Hours, opt => opt.MapFrom(src => src.Begin.Hour))
                .ForMember(dest => dest.Begin.Minutes, opt => opt.MapFrom(src => src.Begin.Minute))
                .ForMember(dest => dest.End.Hours, opt => opt.MapFrom(src => src.End.Hour))
                .ForMember(dest => dest.End.Minutes, opt => opt.MapFrom(src => src.End.Minute));

            CreateMap<Schedule<Salon>, ScheduleDto>();
            CreateMap<ScheduleDto, Schedule<Salon>>();
        }
    }
}
