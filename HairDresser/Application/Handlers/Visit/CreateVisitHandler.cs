using Application.Commands.Visit;
using Infrastructure.DbContexts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Domain.Entities;
using Application.DTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Visit
{
    public class CreateVisitHandler: RequestHandler<CreateVisitCommand, VisitDto>
    {
        HairDresserDbContext _dbContext;
        IMapper _mapper;

        public CreateVisitHandler(HairDresserDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        protected override VisitDto Handle(CreateVisitCommand request)
        {
            var services = _dbContext.Services.Where(s => request.ServiceIds.Contains(s.Id.ToString())).ToArray();
            if(services == null)
            {
                throw new ApplicationException("Could not add visit with no services defined.");
            }

            var visit = new Domain.Entities.Visit(
                new Guid(request.ClientId),
                new Guid(request.WorkerId),
                services,
                new DateTimeOffset(request.Term).LocalDateTime,
                request.TotalTime,
                request.TotalPrice);

            _dbContext.Visits.Add(visit);

            if (_dbContext.SaveChanges() == 0)
            {
                throw new Exception("Could not save created visit into database.");
            }

            var worker = _dbContext.Workers
                .Include(w => w.User)
                .FirstOrDefault(w => w.Id.ToString() == request.WorkerId);

            var result = _mapper.Map<VisitDto>(visit);
            result.WorkerEmail = worker.User.Email;
            result.WorkerFirstName = worker.FirstName;
            result.WorkerId = worker.Id.ToString();
            result.WorkerLastName = worker.LastName;
            result.WorkerPhoneNumber = worker.User.PhoneNumber;
            result.WorkerRating = worker.Rating;
            result.WorkerUserName = worker.User.UserName;

            return result;
        }
    }
}
