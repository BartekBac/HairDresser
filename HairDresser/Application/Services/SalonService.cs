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
using System.Linq;

namespace Application.Services
{
    public class SalonService : ISalonService
    {
        HairDresserDbContext _dbContext;
        IMapper _mapper;

        public SalonService(HairDresserDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public SalonDto CreateSalon(SalonCreationDto salonCreation, IdentityUser admin)
        {
            var existingSalon = _dbContext.Salons.FirstOrDefault(s => s.Id.ToString() == admin.Id);

            if(existingSalon != null)
            {
                throw new ApplicationException("Salon for user [id=" + admin.Id + "] already exists");
            }

            var schedule = _mapper.Map<Schedule>(salonCreation.Schedule);
            
            var salon = new Salon(admin,
                                  salonCreation.Name,
                                  _mapper.Map<Address>(salonCreation.Address),
                                  salonCreation.AdditionalInfo,
                                  salonCreation.Type,
                                  schedule);
            //schedule.SetEntity(salon.Id, salon);
            // TODO: _dbContext.Add(schedule)?
            _dbContext.Salons.Add(salon);

            if (_dbContext.SaveChanges() == 0)
            {
                throw new DomainException("Could not save salon into database.");
            }

            return _mapper.Map<SalonDto>(salon);
        }
    }
}
