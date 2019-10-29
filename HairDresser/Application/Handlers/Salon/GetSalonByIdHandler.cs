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

            var salon = _dbContext.Salons.Include(s => s.Admin).FirstOrDefault(s => s.Id == salonId);
            var image = _dbContext.Images.FirstOrDefault(i => i.Id == salonId);
            var schedule = _dbContext.Schedules.FirstOrDefault(i => i.Id == salonId);
            salon.Image = image;
            salon.Schedule = schedule;
            if (salon == null)
            {
                throw new ApplicationException("Could not find salon with id=" + salonId);
            }
            if (image == null)
            {
                throw new ApplicationException("Could not find image for salon with id=" + salonId);
            }
            if (schedule == null)
            {
                throw new ApplicationException("Could not find schedule for salon with id=" + salonId);
            }

            return _mapper.Map<SalonDto>(salon);
        }
    }
}
