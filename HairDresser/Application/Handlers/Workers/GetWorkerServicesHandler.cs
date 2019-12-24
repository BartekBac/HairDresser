using Application.DTOs;
using Application.Queries.Worker;
using AutoMapper;
using Infrastructure.DbContexts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Workers
{
    public class GetWorkerServicesHandler : RequestHandler<GetWorkerServicesQuery, ServiceDto[]>
    {
        private HairDresserDbContext _dbContext;
        private IMapper _mapper;

        public GetWorkerServicesHandler(HairDresserDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        protected override ServiceDto[] Handle(GetWorkerServicesQuery request)
        {
            Guid workerId = new Guid(request.Id);

            var worker = _dbContext.Workers.Include(w => w.Services).FirstOrDefault(w => w.Id == workerId);

            if(worker == null)
            {
                throw new ApplicationException("Could not find worker with id=" + workerId);
            }

            return _mapper.Map<ServiceDto[]>(worker.Services);
        }
    }
}
