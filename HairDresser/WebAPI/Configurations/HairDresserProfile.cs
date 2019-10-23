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
            CreateMap<Salon, SalonDto>()
                .ForMember(dest => dest.ImageSource, opt => opt.MapFrom(src => Convert.ToBase64String(src.Image.ImageData)));
            //    .ForPath(dest => dest.Address, opt => opt.MapFrom(src => src.Address));
            CreateMap<Day, DayDto>()
                .ForPath(dest => dest.Begin.Hour, opt => opt.MapFrom(src => src.Begin.Hours))
                .ForPath(dest => dest.Begin.Minute, opt => opt.MapFrom(src => src.Begin.Minutes))
                .ForPath(dest => dest.End.Hour, opt => opt.MapFrom(src => src.End.Hours))
                .ForPath(dest => dest.End.Minute, opt => opt.MapFrom(src => src.End.Minutes));

            CreateMap<DayDto, Day>()
                .ForPath(dest => dest.Begin.Hours, opt => opt.MapFrom(src => src.Begin.Hour))
                .ForPath(dest => dest.Begin.Minutes, opt => opt.MapFrom(src => src.Begin.Minute))
                .ForPath(dest => dest.End.Hours, opt => opt.MapFrom(src => src.End.Hour))
                .ForPath(dest => dest.End.Minutes, opt => opt.MapFrom(src => src.End.Minute));

            CreateMap<Schedule<Salon>, ScheduleDto>();
            CreateMap<ScheduleDto, Schedule<Salon>>();
        }
    }
}
