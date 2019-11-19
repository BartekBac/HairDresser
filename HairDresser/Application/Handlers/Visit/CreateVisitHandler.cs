using Application.Commands.Visit;
using Domain.DbContexts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Domain.Entities;

namespace Application.Handlers.Visit
{
    public class CreateVisitHandler: RequestHandler<CreateVisitCommand>
    {
        HairDresserDbContext _dbContext;

        public CreateVisitHandler(HairDresserDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        protected override void Handle(CreateVisitCommand request)
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
        }
    }
}
