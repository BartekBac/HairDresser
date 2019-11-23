using Application.DTOs;
using Application.Queries.Worker;
using AutoMapper;
using Domain.DbContexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Handlers.Workers
{
    public class GetWorkerByIdHandler : RequestHandler<GetWorkerByIdQuery, WorkerDto>
    {
        private HairDresserDbContext _dbContext;
        private IMapper _mapper;

        public GetWorkerByIdHandler(HairDresserDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        protected override WorkerDto Handle(GetWorkerByIdQuery request)
        {
            Guid workerId = new Guid(request.Id);

            var worker = _dbContext.Workers
                .Include(w => w.User)
                .Include(w => w.Visits).ThenInclude(v => v.Client).ThenInclude(c =>c.User)
                .Include(w => w.Visits).ThenInclude(v => v.Services).ThenInclude(vs => vs.Service)
                .Include(w => w.Services).ThenInclude(ws => ws.Service)
                .FirstOrDefault(w => w.Id == workerId);

            if (worker == null)
            {
                throw new ApplicationException("Could not find worker with id=" + workerId);
            }
            var image = _dbContext.Images.FirstOrDefault(i => i.Id == workerId);
            if (image == null)
            {
                throw new ApplicationException("Could not find image for worker with id=" + workerId);
            }
            var schedule = _dbContext.Schedules.FirstOrDefault(s => s.Id == workerId);
            if (schedule == null)
            {
                throw new ApplicationException("Could not find image for worker with id=" + workerId);
            }
            worker.Image = image;
            worker.Schedule = schedule;

            return _mapper.Map<WorkerDto>(worker);
        }
    }
}
