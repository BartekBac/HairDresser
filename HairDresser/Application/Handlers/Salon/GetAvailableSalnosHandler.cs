using Application.DTOs;
using Application.Queries.Salon;
using AutoMapper;
using Infrastructure.DbContexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Handlers.Salon
{
    public class GetAvailableSalonsHandler : RequestHandler<GetAvailableSalonsQuery, SalonDto[]>
    {
        private HairDresserDbContext _dbContext;
        private IMapper _mapper;

        public GetAvailableSalonsHandler(HairDresserDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        protected override SalonDto[] Handle(GetAvailableSalonsQuery request)
        {
            var salons = _dbContext.Salons
                .Include(s => s.Admin)
                .Include(s => s.Services)
                .Where(s => !s.Clients.Select(cs => cs.ClientId).Contains(new Guid(request.clientId)))
                .AsQueryable();

            foreach (var salon in salons)
            {
                var image = _dbContext.Images.FirstOrDefault(i => i.Id == salon.Id);
                var schedule = _dbContext.Schedules.FirstOrDefault(s => s.Id == salon.Id);
                if (image != null)
                {
                    salon.Image = image;
                }
                if (schedule != null)
                {
                    salon.Schedule = schedule;
                }
            }

            return _mapper.Map<SalonDto[]>(salons);
        }
    }
}
