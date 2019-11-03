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
            var worker = _dbContext.Workers.FirstOrDefault(w => w.Id.ToString() == request.WorkerId);

            if(worker == null)
            {
                throw new ApplicationException("Cannot assign services because worker with id=" + request.WorkerId + "do not exists.");
            }

            foreach(var service in request.Services)
            {
                if(service == null)
                {
                    throw new ApplicationException("Cannot assign null service.");
                }

                worker.AssignService(new Guid(service.Id));
            }

            if (_dbContext.SaveChanges() == 0)
            {
                throw new Exception("Could not save assigned services to worker into database.");
            }
        }
    }
}
