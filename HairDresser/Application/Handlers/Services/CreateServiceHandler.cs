using Application.Commands.Services;
using AutoMapper;
using Domain.DbContexts;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Handlers.Services
{
    public class CreateServiceHandler : RequestHandler<CreateServiceCommand>
    {
        HairDresserDbContext _dbContext;

        public CreateServiceHandler(HairDresserDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        protected override void Handle(CreateServiceCommand request)
        {

            var service = new Service(
                request.Name,
                request.Price,
                request.Time,
                new Guid(request.SalonId)
                );

            _dbContext.Services.Add(service);

            if (_dbContext.SaveChanges() == 0)
            {
                throw new Exception("Could not save created service into database.");
            }
        }
    }
}
