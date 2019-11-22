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
using System.Globalization;

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

            request.Term = new DateTimeOffset(request.Term).LocalDateTime;

            if (request.Term < DateTime.Now)
            {
                throw new ApplicationException("Could not change visit date to past date");
            }

            var thisOtherDayWorkerVisits = _dbContext.Visits.
                Where(v => v.Worker.Id == visit.Worker.Id 
                      && v.Status != VisitStatus.Rejected
                      && v.Term.Date == request.Term.Date
                      && v.Id != visit.Id);

            if (thisOtherDayWorkerVisits.Any())
            {
                var collidingVisits = thisOtherDayWorkerVisits.
                    Where(v => (v.Term <= request.Term && v.Term.AddMinutes(v.TotalTime) > request.Term) 
                            || (v.Term > request.Term && v.Term < request.Term.AddMinutes(visit.TotalTime)));

                if (collidingVisits.Any())
                {
                    throw new ApplicationException("Could not change visit date to already occupied date");
                }
            }

            var visitTermString = visit.Term.ToString(new CultureInfo("pl-PL"));
            visitTermString = visitTermString.Substring(0, visitTermString.Length - 3);
            var requestTermString = request.Term.ToString(new CultureInfo("pl-PL"));
            requestTermString = requestTermString.Substring(0, requestTermString.Length - 3);
            var info = "requests to change date of the visit"
                         + " from: " + visitTermString
                         + " to: " + requestTermString;
            visit.SetTerm(request.Term);
            if (request.IsWorkerRequesting)
            {
                visit.SetStatus(VisitStatus.WorkerChangeRequested);
                visit.SetInfo("Hairdresser " + info);
            } 
            else
            {
                if (visit.Status != VisitStatus.Pending)
                {
                    visit.SetStatus(VisitStatus.ClientChangeRequested);
                    visit.SetInfo("Client " + info);
                }
            }            

            if (_dbContext.SaveChanges() == 0)
            {
                throw new Exception("Could not save visit changes into database.");
            }

            return _mapper.Map<VisitDto>(visit);
        }
    }
}
