using Application.Commands.Workers;
using Domain.DbContexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Handlers.Workers
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
                /*.Include(w => w.Salon).ThenInclude(s => s.Workers)*/
                .Include(w => w.Services)
                .Include(w => w.Visits).ThenInclude(v => v.Services)
                .Include(w => w.Opinions)
                .FirstOrDefault(s => s.Id == workerId);
            if (worker == null)
            {
                throw new ApplicationException("Could not find worker with id=" + workerId);
            }

            var activeVisits = worker.Visits.Where(v => (v.Status != Domain.Enums.VisitStatus.Rejected) && v.Term > DateTime.Now);
            if(activeVisits.Any())
            {
                throw new ApplicationException("Before delete worker, he has to reject all his pending/accpeted/change-requested upcoming visits");
            }

            //var workerSalon = _dbContext.Salons.FirstOrDefault(s => s.Id == worker.SalonId);

            if(worker.Opinions.Any())
            {
                var workerSalon = _dbContext.Salons.Include(s => s.Workers).FirstOrDefault(s => s.Id == worker.SalonId);
                worker.Salon = workerSalon;
                foreach (var opinion in worker.Opinions)
                {
                    worker.RevertRating(opinion.Rate);
                    var opinionImage = _dbContext.Images.FirstOrDefault(i => i.Id == opinion.Id);
                    if (opinionImage != null)
                    {
                        _dbContext.Images.Remove(opinionImage);
                    }
                    _dbContext.Opinions.Remove(opinion);
                }
            }

            if(worker.Visits.Any())
            {
                foreach(var visit in worker.Visits)
                {
                    _dbContext.VisitServices.RemoveRange(visit.Services);
                    _dbContext.Visits.Remove(visit);
                }
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
