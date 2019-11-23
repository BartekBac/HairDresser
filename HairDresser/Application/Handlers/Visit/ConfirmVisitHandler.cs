using Application.Commands.Visit;
using Application.DTOs;
using AutoMapper;
using Domain.DbContexts;
using Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Handlers.Visit
{
    public class ConfirmVisitHandler : RequestHandler<ConfirmVisitCommand, VisitDto>
    {
        HairDresserDbContext _dbContext;
        IMapper _mapper;

        public ConfirmVisitHandler(HairDresserDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        protected override VisitDto Handle(ConfirmVisitCommand request)
        {
            var visit = _dbContext.Visits.Include(v => v.Worker).FirstOrDefault(v => v.Id == new Guid(request.Id));
            if (visit == null)
            {
                throw new ApplicationException("Could not find visit with id=" + request.Id);
            }

            if (visit.Term < DateTime.Now)
            {
                throw new ApplicationException("Could not change old visits");
            }

            var thisDayOtherWorkerVisits = _dbContext.Visits.
                    Where(v => v.Worker.Id == visit.Worker.Id
                        && v.Status != VisitStatus.Rejected
                        && v.Term.Date == visit.Term.Date
                        && v.Id != visit.Id);

            if (thisDayOtherWorkerVisits.Any())
            {
                var collidingVisits = thisDayOtherWorkerVisits.
                    Where(v => (v.Term <= visit.Term && v.Term.AddMinutes(v.TotalTime) > visit.Term)
                            || (v.Term > visit.Term && v.Term < visit.Term.AddMinutes(visit.TotalTime)));

                if (collidingVisits.Any())
                {
                    throw new ApplicationException("Could not confirm visit. Worker has other not rejected visits at this time.");
                }
            }

            visit.SetStatus(VisitStatus.Accepted);
            visit.SetInfo("Visit confirmed.");


            if (_dbContext.SaveChanges() == 0)
            {
                throw new Exception("Could not save visit changes into database.");
            }

            return _mapper.Map<VisitDto>(visit);
        }
    }
}
