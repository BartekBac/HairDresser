﻿using Application.DTOs;
using Application.Queries.Client;
using AutoMapper;
using Infrastructure.DbContexts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Application.Services;
using Domain.ValueObjects;
using Domain.Entities;

namespace Application.Handlers.Client
{
    public class GetClientByIdHandler : RequestHandler<GetClientByIdQuery, ClientDto>
    {
        private HairDresserDbContext _dbContext;
        private IMapper _mapper;

        public GetClientByIdHandler(HairDresserDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        protected override ClientDto Handle(GetClientByIdQuery request)
        {
            Guid clientId = new Guid(request.Id);

            var client = _dbContext.Clients
                .Include(c => c.User)
                .Include(c => c.SendOpinions).ThenInclude(o => o.Worker)
                .FirstOrDefault(c => c.Id == clientId);

            var image = _dbContext.Images.FirstOrDefault(i => i.Id == clientId);
            if (client == null)
            {
                throw new ApplicationException("Could not find client with id=" + clientId);
            }
            if (image == null)
            {
                throw new ApplicationException("Could not find image for client with id=" + clientId);
            }
            client.Image = image;
            var result = _mapper.Map<ClientDto>(client);

            var clientSalons = _dbContext.ClientSalons.Where(cs => cs.ClientId == clientId).ToArray();

            foreach(var clientSalon in clientSalons)
            {
                var salon = _dbContext.Salons
                    .Include(s => s.Admin)
                    .Include(s => s.Workers).ThenInclude(w => w.User)
                    .Include(s => s.Workers).ThenInclude(w => w.Opinions)
                    .Include(s => s.Workers).ThenInclude(w => w.Services).ThenInclude(ws => ws.Service)
                    .Include(s => s.Services)
                    .FirstOrDefault(s => s.Id == clientSalon.SalonId);
                if(salon == null)
                {
                    throw new ApplicationException("Could not find favorite salon with id=" + clientSalon.SalonId.ToString());
                }
                var salonImage = _dbContext.Images.FirstOrDefault(i => i.Id == salon.Id);
                if (salonImage == null)
                {
                    throw new ApplicationException("Could not find image for favorite salon with id=" + clientSalon.SalonId.ToString());
                }
                var salonSchedule = _dbContext.Schedules.FirstOrDefault(s => s.Id == salon.Id);
                if (salonSchedule == null)
                {
                    throw new ApplicationException("Could not find schedule for favorite salon with id=" + clientSalon.SalonId.ToString());
                }
                salon.Image = salonImage;
                salon.Schedule = salonSchedule;

                foreach(var worker in salon.Workers)
                {
                    var workerImage = _dbContext.Images.FirstOrDefault(i => i.Id == worker.Id);
                    var workerSchedule = _dbContext.Schedules.FirstOrDefault(s => s.Id == worker.Id);
                    worker.Image = workerImage;
                    worker.Schedule = workerSchedule;

                    foreach(var opinion in worker.Opinions)
                    {
                        var opinionImage = _dbContext.Images.FirstOrDefault(i => i.Id == opinion.Id);
                        opinion.Image = opinionImage;
                    }
                }

                result.FavoriteSalons = result.FavoriteSalons.AsEnumerable().Concat(new SalonDto[] { _mapper.Map<SalonDto>(salon) });
            };

            foreach (var opinion in client.SendOpinions)
            {
                var opinionImage = _dbContext.Images.FirstOrDefault(i => i.Id == opinion.Id);
                opinion.Image = opinionImage;
            }

            result.SendOpinions = _mapper.Map<OpinionDto[]>(client.SendOpinions);

            var visits = _dbContext.Visits
                .Include(v => v.Services).ThenInclude(vs => vs.Service)
                .Where(v => v.ClientId == clientId);
 
            result.Visits = _mapper.Map<VisitDto[]>(visits);

            return result;
        }
    }
}
