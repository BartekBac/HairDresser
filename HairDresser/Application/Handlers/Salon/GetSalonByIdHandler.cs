using Application.DTOs;
using Application.Queries.Salon;
using Domain.DbContexts;
using MediatR;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace Application.Handlers.Salon
{
    public class GetSalonByIdHandler : RequestHandler<GetSalonByIdQuery, SalonDto>
    {
        private HairDresserDbContext _dbContext;
        private IMapper _mapper;

        public GetSalonByIdHandler(HairDresserDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        protected override SalonDto Handle(GetSalonByIdQuery request)
        {
            Guid salonId = new Guid(request.Id.ToString());

            var salon = _dbContext.Salons.FirstOrDefault(s => s.Id == salonId);

            if (salon == null)
            {
                throw new ApplicationException("Could not find salon with id="+salonId);
            }

            return _mapper.Map<SalonDto>(salon);
        }
    }
}
