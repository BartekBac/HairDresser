using Application.Commands;
using AutoMapper;
using Infrastructure.DbContexts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Handlers.Workers
{
    public class UpdateWorkerDataHandler: RequestHandler<UpdateWorkerDataCommand>
    {
        private HairDresserDbContext _dbContext;
        private IMapper _mapper;

        public UpdateWorkerDataHandler(HairDresserDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        protected override void Handle(UpdateWorkerDataCommand request)
        {
            Guid workerId = new Guid(request.Id.ToString());

            var worker = _dbContext.Workers.FirstOrDefault(s => s.Id == workerId);
            if (worker == null)
            {
                throw new ApplicationException("Could not find worker with id=" + workerId);
            }

            if (worker.UpdateData(request.FirstName, request.LastName))
            {
                if (_dbContext.SaveChanges() == 0)
                {
                    throw new Exception("Could not save worker data changes into database.");
                }
            }
        }
    }
}
