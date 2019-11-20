using Application.DTOs;
using Application.Services;
using AutoMapper;
using AutoMapper.Configuration;
using Domain.Entities;
using Domain.Entities.ManyToMany;
using Domain.ValueObjects;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
            CreateMap<Client, ClientDto>()
                .ForPath(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName));

            CreateMap<Salon, SalonDto>()
                .ForMember(dest => dest.ImageSource, opt => opt.MapFrom(src => ImageService.ConcatenateToString(src.Image)));
            //.ForMember(dest => dest.ImageSource, opt => opt.MapFrom(src => src.Image.Header + Convert.ToBase64String(src.Image.Source)));

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

            CreateMap<Schedule, ScheduleDto>();
            CreateMap<ScheduleDto, Schedule>();
            CreateMap<Worker, WorkerDto>()
                .ForPath(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
                .ForMember(dest => dest.ImageSource, opt => opt.MapFrom(src => ImageService.ConcatenateToString(src.Image)));

            CreateMap<Service, ServiceDto>();

            CreateMap<WorkerServices, ServiceDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Service.Name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Service.Price))
                .ForMember(dest => dest.Time, opt => opt.MapFrom(src => src.Service.Time))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Service.Id));

            CreateMap<VisitServices, ServiceDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Service.Name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Service.Price))
                .ForMember(dest => dest.Time, opt => opt.MapFrom(src => src.Service.Time))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Service.Id));

            CreateMap<ClientSalons, SalonDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Salon.Name))
                .ForMember(dest => dest.AdditionalInfo, opt => opt.MapFrom(src => src.Salon.AdditionalInfo))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Salon.Type))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Salon.Address))
                .ForMember(dest => dest.Admin, opt => opt.MapFrom(src => src.Salon.Admin));

            CreateMap<Visit, VisitDto>()
                .AfterMap((src, dest) => 
                {
                    if(dest.Client != null)
                    {
                        dest.Client.Visits = null;
                    }
                });
        }
    }
}
