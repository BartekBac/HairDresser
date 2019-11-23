using Application.Commands.Visit;
using Application.DTOs;
using AutoMapper;
using Domain.DbContexts;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Handlers.Visit
{
    public class RejectVisitHandler : RequestHandler<RejectVisitCommand, VisitDto>
    {
        HairDresserDbContext _dbContext;
        IMapper _mapper;

        public RejectVisitHandler(HairDresserDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        protected override VisitDto Handle(RejectVisitCommand request)
        {
            var visit = _dbContext.Visits.FirstOrDefault(v => v.Id == new Guid(request.Id));
            if (visit == null)
            {
                throw new ApplicationException("Could not find visit with id=" + request.Id);
            }

            if (visit.Term < DateTime.Now)
            {
                throw new ApplicationException("Could not change old visits");
            }

            visit.SetStatus(VisitStatus.Rejected);

            var info = "Visit rejected by ";
            if (request.IsWorkerRejecting)
            {
                info += "hairdresser.";
            }
            else
            {
                info += "client.";
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
