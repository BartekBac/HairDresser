using Application.Commands.Opinion;
using Infrastructure.DbContexts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Handlers.Opinion
{
    public class UpdateOpinionAnswerHandler : RequestHandler<UpdateOpinionAnswerCommand>
    {
        private HairDresserDbContext _dbContext;

        public UpdateOpinionAnswerHandler(HairDresserDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        protected override void Handle(UpdateOpinionAnswerCommand request)
        {
            Guid opinionId = new Guid(request.Id);

            var opinion = _dbContext.Opinions.FirstOrDefault(s => s.Id == opinionId);
            if (opinion == null)
            {
                throw new ApplicationException("Could not find opinion with id=" + opinionId);
            }

            opinion.SetAnswer(request.Answer);

            if (_dbContext.SaveChanges() == 0)
            {
                throw new ApplicationException("Could not update opinion in database.");
            }
        }
    }
}
