using Application.Commands.Opinion;
using Domain.DbContexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Handlers.Opinion
{
    public class DeleteOpinionHandler : RequestHandler<DeleteOpinionCommand>
    {
        private HairDresserDbContext _dbContext;

        public DeleteOpinionHandler(HairDresserDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        protected override void Handle(DeleteOpinionCommand request)
        {
            Guid opinionId = new Guid(request.Id);

            var opinion = _dbContext.Opinions.FirstOrDefault(s => s.Id == opinionId);
            if (opinion == null)
            {
                throw new ApplicationException("Could not find opinion with id=" + opinionId);
            }
            var worker = _dbContext.Workers
                .FirstOrDefault(w => w.Id == opinion.WorkerId);
            var workerSalon = _dbContext.Salons.Include(s => s.Workers).FirstOrDefault(s => s.Id == worker.SalonId);
            worker.Salon = workerSalon;
            if (worker == null)
            {
                throw new ApplicationException("Could not find worker with id=" + opinion.WorkerId + " not found.");
            }
            worker.RevertRating(opinion.Rate);
            var image = _dbContext.Images.FirstOrDefault(i => i.Id == opinion.Id);
            if (image != null)
            {
                _dbContext.Images.Remove(image);
            }

            _dbContext.Opinions.Remove(opinion);

            if (_dbContext.SaveChanges() == 0)
            {
                throw new ApplicationException("Could not delete opinion from database.");
            }
        }
    }
}
