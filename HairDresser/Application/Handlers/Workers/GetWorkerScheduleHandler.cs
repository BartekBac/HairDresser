using Application.DTOs;
using Application.Queries.Worker;
using AutoMapper;
using Domain.DbContexts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Workers
{
    public class GetWorkerScheduleHandler : RequestHandler<GetWorkerScheduleQuery, ScheduleDto>
    {
        private HairDresserDbContext _dbContext;
        private IMapper _mapper;

        public GetWorkerScheduleHandler(HairDresserDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        protected override ScheduleDto Handle(GetWorkerScheduleQuery request)
        {
            Guid workerId = new Guid(request.Id);

            var schedule = _dbContext.Schedules.FirstOrDefault(w => w.Id == workerId);

            if(schedule == null)
            {
                throw new ApplicationException("Could not find schedule for worker with id=" + workerId);
            }

            return _mapper.Map<ScheduleDto>(schedule);
        }
    }
}
