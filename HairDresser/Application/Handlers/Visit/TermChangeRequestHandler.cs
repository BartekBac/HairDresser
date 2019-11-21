using Application.Commands.Visit;
using Domain.DbContexts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Domain.Enums;
using Application.DTOs;
using AutoMapper;

namespace Application.Handlers.Visit
{
    public class TermChangeRequestHandler : RequestHandler<TermChangeRequestCommand, VisitDto>
    {
        HairDresserDbContext _dbContext;
        IMapper _mapper;

        public TermChangeRequestHandler(HairDresserDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        protected override VisitDto Handle(TermChangeRequestCommand request)
        {
            var visit = _dbContext.Visits.Include(v => v.Worker).FirstOrDefault(v => v.Id == new Guid(request.VisitId));
            if (visit == null)
            {
                throw new ApplicationException("Could not find visit with id=" + request.VisitId);
            }

            if (visit.Term < DateTime.Now)
            {
                throw new ApplicationException("Could not change old visits");
            }

            if (request.Term < DateTime.Now)
            {
                throw new ApplicationException("Could not change visit date to past date");
            }

            var thisDayWorkerVisits = _dbContext.Visits.
                Where(v => v.Worker.Id == visit.Worker.Id 
                      && v.Status != VisitStatus.Rejected
                      && v.Term.Date == request.Term.Date);

            if (thisDayWorkerVisits.Any())
            {
                var collidingVisits = thisDayWorkerVisits.
                    Where(v => (v.Term <= request.Term && v.Term.AddMinutes(v.TotalTime) > request.Term) 
                            || (v.Term > request.Term && v.Term < request.Term.AddMinutes(visit.TotalTime)));

                if (collidingVisits.Any())
                {
                    throw new ApplicationException("Could not change visit date to already occupied date");
                }
            }

            visit.SetTerm(request.Term);
            var info = " requests to change date of the visit to: " + request.Term.ToLongTimeString();
            if(request.IsWorkerRequesting)
            {
                visit.SetStatus(VisitStatus.WorkerChangeRequested);
                info = "Hairdresser" + info;
            } 
            else
            {
                visit.SetStatus(VisitStatus.ClientChangeRequested);
                info = "Client" + info;
            }

            visit.SetInfo(info);

            if (_dbContext.SaveChanges() == 0)
            {
                throw new Exception("Could not save visit changes into database.");
            }

            return _mapper.Map<VisitDto>(visit);
        }
    }
}
