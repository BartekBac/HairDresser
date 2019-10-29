using Application.DTOs;
using Application.Queries.Salon;
using Domain.DbContexts;
using MediatR;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Application.Commands;
using Domain.ValueObjects;

namespace Application.Handlers.Salon
{
    public class UpdateSalonDataHandler: RequestHandler<UpdateSalonDataCommand>
    {
        private HairDresserDbContext _dbContext;
        private IMapper _mapper;

        public UpdateSalonDataHandler(HairDresserDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        protected override void Handle(UpdateSalonDataCommand request)
        {
            Guid salonId = new Guid(request.Id.ToString());

            var salon = _dbContext.Salons.FirstOrDefault(s => s.Id == salonId);
            if (salon == null)
            {
                throw new ApplicationException("Could not find salon with id=" + salonId);
            }

            salon.UpdateData(
                request.Name,
                request.AdditionalInfo,
                _mapper.Map<Address>(request.Address),
                request.Type);


            if (_dbContext.SaveChanges() == 0)
            {
                throw new Exception("Could not save salon data changes into database.");
            }
        }
    }
}
