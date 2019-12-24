using Application.Commands.Services;
using Application.DTOs;
using AutoMapper;
using Infrastructure.DbContexts;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Handlers.Services
{
    public class CreateServiceHandler : RequestHandler<CreateServiceCommand, ServiceDto>
    {
        HairDresserDbContext _dbContext;
        IMapper _mapper;

        public CreateServiceHandler(HairDresserDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        protected override ServiceDto Handle(CreateServiceCommand request)
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

            return _mapper.Map<ServiceDto>(service);
        }
    }
}
