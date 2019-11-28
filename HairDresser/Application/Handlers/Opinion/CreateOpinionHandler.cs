using Application.Commands.Opinion;
using Application.DTOs;
using Application.Services;
using AutoMapper;
using Domain.DbContexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Handlers.Opinion
{
    public class CreateOpinionHandler : RequestHandler<CreateOpinionCommand, OpinionDto>
    {
        HairDresserDbContext _dbContext;
        IMapper _mapper;

        public CreateOpinionHandler(HairDresserDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        protected override OpinionDto Handle(CreateOpinionCommand request)
        {
            var client = _dbContext.Clients.FirstOrDefault(c => c.Id.ToString() == request.ClientId);
            if (client == null)
            {
                throw new ApplicationException("Could not add opinion, client with id="+request.ClientId+" not found.");
            }
            var worker = _dbContext.Workers
                .FirstOrDefault(w => w.Id.ToString() == request.WorkerId);
            var workerSalon = _dbContext.Salons.Include(s => s.Workers).FirstOrDefault(s => s.Id == worker.SalonId);
            worker.Salon = workerSalon;
            if (worker == null)
            {
                throw new ApplicationException("Could not add opinion, worker with id=" + request.WorkerId + " not found.");
            }
            var visit = _dbContext.Visits.FirstOrDefault(v => v.Id.ToString() == request.VisitId);
            if (visit == null)
            {
                throw new ApplicationException("Could not add opinion, visit with id=" + request.VisitId + " not found.");
            }
            visit.SetOpinionSent(true);

            var resolvedImage = ImageService.ResolveToImage(request.ImageSource);

            var opinion = new Domain.Entities.Opinion(
                new Guid(request.ClientId),
                new Guid(request.WorkerId),
                request.Description,
                request.Rate,
                resolvedImage.Source,
                resolvedImage.Header);

            worker.UpdateRating(request.Rate);
            _dbContext.Opinions.Add(opinion);

            if (_dbContext.SaveChanges() == 0)
            {
                throw new Exception("Could not save created opinion into database.");
            }

            var result = _mapper.Map<OpinionDto>(opinion);
            result.ClientId = client.Id.ToString();
            result.ClientFirstName = client.FirstName;
            result.ClientLastName = client.LastName;
            result.WorkerId = worker.Id.ToString();
            result.WorkerFirstName = worker.FirstName;
            result.WorkerLastName = worker.LastName;

            return result;
        }
    }
}
