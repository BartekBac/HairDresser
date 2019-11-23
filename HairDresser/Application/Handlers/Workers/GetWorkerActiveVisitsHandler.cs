using Application.DTOs;
using Application.Queries.Worker;
using AutoMapper;
using Domain.DbContexts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.Handlers.Workers
{
    public class GetWorkerActiveVisitsHandler : RequestHandler<GetWorkerActiveVisitsQuery, VisitDto[]>
    {
        private HairDresserDbContext _dbContext;
        private IMapper _mapper;

        public GetWorkerActiveVisitsHandler(HairDresserDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        protected override VisitDto[] Handle(GetWorkerActiveVisitsQuery request)
        {
            Guid workerId = new Guid(request.Id);

            var worker = _dbContext.Workers.Include(w => w.Visits).FirstOrDefault(w => w.Id == workerId);

            if (worker == null)
            {
                throw new ApplicationException("Could not find worker with id=" + workerId);
            }

            var visitsToReturn = worker.Visits.Where(v => (v.Status != Domain.Enums.VisitStatus.Rejected) && v.Term > DateTime.Now);

            return _mapper.Map<VisitDto[]>(visitsToReturn);
        }
    }
}
