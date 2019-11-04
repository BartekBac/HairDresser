using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using AutoMapper;
using Application.DTOs;
using Domain.DbContexts;
using Application.Commands.Workers;
using System.Linq;
using Domain.Entities;
using Domain.Entities.ManyToMany;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Workers
{
    public class AssignWorkerServicesHandler : RequestHandler<AssignWorkerServicesCommand>
    {
        HairDresserDbContext _dbContext;
        IMapper _mapper;

        public AssignWorkerServicesHandler(HairDresserDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        protected override void Handle(AssignWorkerServicesCommand request)
        {
            var worker = _dbContext.Workers.Include(w => w.Services).FirstOrDefault(w => w.Id.ToString() == request.WorkerId);

            if(worker == null)
            {
                throw new ApplicationException("Cannot assign services because worker with id=" + request.WorkerId + "do not exists.");
            }

            worker.ClearAssignedServices();

            var servicesToAssign = _dbContext.Services.Where(ser => ser.SalonId == worker.SalonId && request.Services.Select(s => s.Id).Contains(ser.Id.ToString()));

            if (servicesToAssign.Any())
            {
                foreach (var service in servicesToAssign)
                {
                    worker.AssignService(service);
                }
            }

            if (_dbContext.SaveChanges() == 0)
            {
                throw new Exception("Could not save assigned services to worker into database.");
            }
        }
    }
}
