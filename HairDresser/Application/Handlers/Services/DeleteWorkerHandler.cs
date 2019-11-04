using Application.Commands.Workers;
using Domain.DbContexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Handlers.Services
{
    public class DeleteWorkerHandler : RequestHandler<DeleteWorkerCommand>
    {
        private HairDresserDbContext _dbContext;

        public DeleteWorkerHandler(HairDresserDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        protected override void Handle(DeleteWorkerCommand request)
        {
            Guid workerId = new Guid(request.Id);

            var worker = _dbContext.Workers
                .Include(w => w.User)
                .Include(w => w.Services)
                .FirstOrDefault(s => s.Id == workerId);
            if (worker == null)
            {
                throw new ApplicationException("Could not find worker with id=" + workerId);
            }

            var image = _dbContext.Images.FirstOrDefault(i => i.Id == workerId);
            var schedule = _dbContext.Schedules.FirstOrDefault(s => s.Id == workerId);
            var user = _dbContext.Users.FirstOrDefault(u => u.Id == workerId.ToString());

            if(image != null)
            {
                _dbContext.Images.Remove(image);
            }
            if(schedule != null)
            {
                _dbContext.Schedules.Remove(schedule);
            }
            if (user != null)
            {
                _dbContext.Users.Remove(user);
            }

            worker.ClearAssignedServices();

            _dbContext.Workers.Remove(worker);

            if (_dbContext.SaveChanges() == 0)
            {
                throw new ApplicationException("Could not delete worker from database.");
            }
        }
    }
}
