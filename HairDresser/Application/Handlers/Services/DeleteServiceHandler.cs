using Application.Commands.Services;
using AutoMapper;
using Infrastructure.DbContexts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Domain.Entities.ManyToMany;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Services
{
    public class DeleteServiceHandler : RequestHandler<DeleteServiceCommand>
    {
        private HairDresserDbContext _dbContext;

        public DeleteServiceHandler(HairDresserDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        protected override void Handle(DeleteServiceCommand request)
        {
            Guid serviceId = new Guid(request.Id);

            var service = _dbContext.Services
                .Include(s => s.VisitsHistory).ThenInclude(vs => vs.Visit).ThenInclude(v => v.Services)
                .FirstOrDefault(s => s.Id == serviceId);
            if (service == null)
            {
                throw new ApplicationException("Could not find service with id=" + serviceId);
            }

            var activeVisits = service.VisitsHistory.Select(vs => vs.Visit).Where(v => (v.Status != Domain.Enums.VisitStatus.Rejected) && v.Term > DateTime.Now);
            if (activeVisits.Any())
            {
                throw new ApplicationException("Before delete service, workers have to reject all pending/accpeted/change-requested upcoming visits which provides this service.");
            }

            if (service.VisitsHistory.Any())
            {
                foreach (var visit in service.VisitsHistory.Select(vs => vs.Visit))
                {
                    _dbContext.VisitServices.RemoveRange(visit.Services);
                    _dbContext.Visits.Remove(visit);
                }
            }

            var salonWorkers = _dbContext.Workers
                .Include(w => w.Services)
                .Where(w => w.SalonId == service.SalonId);

            foreach(var worker in salonWorkers)
            {
                worker.RemoveAssignedService(service);
            }

            _dbContext.Services.Remove(service);

            if (_dbContext.SaveChanges() == 0)
            {
                throw new ApplicationException("Could not delete service from database.");
            }
        }
    }
}
