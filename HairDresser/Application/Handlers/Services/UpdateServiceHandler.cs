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
    public class UpdateServiceHandler : RequestHandler<UpdateServiceCommand>
    {
        private HairDresserDbContext _dbContext;

        public UpdateServiceHandler(HairDresserDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        protected override void Handle(UpdateServiceCommand request)
        {
            Guid serviceId = new Guid(request.Id);

            var service = _dbContext.Services.FirstOrDefault(s => s.Id == serviceId);
            if (service == null)
            {
                throw new ApplicationException("Could not find service with id=" + serviceId);
            }

            if (service.Update(
                request.Name,
                request.Price,
                request.Time))
            {
                if (_dbContext.SaveChanges() == 0)
                {
                    throw new Exception("Could not save service changes into database.");
                }
            }
        }
    }
}
