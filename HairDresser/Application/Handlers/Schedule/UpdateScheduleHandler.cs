using Application.Commands;
using Domain.DbContexts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using Application.DTOs;

namespace Application.Handlers.Image
{
    public class UpdateScheduleHandler : RequestHandler<UpdateScheduleCommand>
    {
        HairDresserDbContext _dbContext;
        IMapper _mapper;
        public UpdateScheduleHandler(HairDresserDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        protected override void Handle(UpdateScheduleCommand request)
        {
            Guid scheduleId = new Guid(request.Id.ToString());
            var schedule = _dbContext.Schedules.FirstOrDefault(i => i.Id == scheduleId);
            if(schedule == null)
            {
                throw new ApplicationException("Could not update schedule. Not found refernce for this entity in Schedules table.");
            }
            var newSchedule = _mapper.Map<Schedule>(request.Schedule);
            if(schedule.Update(newSchedule))
            { 
                if (_dbContext.SaveChanges() == 0)
                {
                    throw new Exception("Could not save schedule changes into database.");
                }
            }
        }
    }
}
