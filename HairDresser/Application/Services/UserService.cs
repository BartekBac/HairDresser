using Application.DTOs;
using AutoMapper;
using Domain.DbContexts;
using Domain.Entities;
using Domain.Exceptions;
using Domain.ValueObjects;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class UserService : IUserService
    {
        HairDresserDbContext _dbContext;
        IMapper _mapper;

        public UserService(HairDresserDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public SalonDto CreateSalon(SalonCreationDto salonCreation, IdentityUser admin)
        {
            var salon = new Salon(admin,
                                  salonCreation.Name,
                                  _mapper.Map<Address>(salonCreation.Address),
                                  salonCreation.AdditionalInfo,
                                  salonCreation.Type);

            _dbContext.Salons.Add(salon);

            if (_dbContext.SaveChanges() == 0)
            {
                throw new DomainException("Could not create salon.");
            }

            var ret = _mapper.Map<SalonDto>(salon);
            return ret;
        }
    }
}
