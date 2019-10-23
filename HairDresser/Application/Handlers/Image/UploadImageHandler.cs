using Application.Commands;
using Domain.DbContexts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Image
{
    public class UploadImageHandler : RequestHandler<UploadImageCommand>
    {
        HairDresserDbContext _dbContext;
        public UploadImageHandler(HairDresserDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        protected override void Handle(UploadImageCommand request)
        {
            int headerLength = request.ImageSource.IndexOf(',') + 1;
            var header = request.ImageSource.Substring(0, headerLength);
            var convertedString = Convert.FromBase64String(request.ImageSource.Substring(headerLength));
            if (request.EntityType == "salon")
            {
                var entity = _dbContext.Salons.Include(s => s.Image).FirstOrDefault(s => s.Id == request.EntityId);
                if (entity == null)
                {
                    throw new ApplicationException("Could not upload image. Unknown salon id.");
                }
                
                entity.Image.SetImageData(convertedString);
            } 
            else if (request.EntityType == "client")
            {
                var entity = _dbContext.Clients.Include(c => c.Image).FirstOrDefault(s => s.Id == request.EntityId);
                if (entity == null)
                {
                    throw new ApplicationException("Could not upload image. Unknown client id.");
                }
                
                entity.Image.SetImageData(convertedString);
            }
            else if (request.EntityType == "worker")
            {
                var entity = _dbContext.Workers.Include(w => w.Image).FirstOrDefault(s => s.Id == request.EntityId);
                if (entity == null)
                {
                    throw new ApplicationException("Could not upload image. Unknown worker id.");
                }
                
                entity.Image.SetImageData(convertedString);
            }
            else if (request.EntityType == "opinion")
            {
                var entity = _dbContext.Opinions.Include(o => o.Image).FirstOrDefault(s => s.Id == request.EntityId);
                if (entity == null)
                {
                    throw new ApplicationException("Could not upload image. Unknown opinion id.");
                }
                
                entity.Image.SetImageData(convertedString);
            } else
            {
                throw new ApplicationException(request.EntityType + " object type has no image attribute in database.");
            }

            if (_dbContext.SaveChanges() == 0)
            {
                throw new Exception("Could not upload image to database.");
            }
        }
    }
}
