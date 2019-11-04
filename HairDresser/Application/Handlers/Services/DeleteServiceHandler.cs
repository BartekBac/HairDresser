using Application.Commands.Services;
using AutoMapper;
using Domain.DbContexts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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

            var service = _dbContext.Services.FirstOrDefault(s => s.Id == serviceId);
            if (service == null)
            {
                throw new ApplicationException("Could not find service with id=" + serviceId);
            }

            _dbContext.Services.Remove(service);

            if (_dbContext.SaveChanges() == 0)
            {
                throw new ApplicationException("Could not delete service from database.");
            }
        }
    }
}
