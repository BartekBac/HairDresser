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
            var convertedSource = Convert.FromBase64String(request.ImageSource.Substring(headerLength));
            var image = _dbContext.Images.FirstOrDefault(i => i.Id == request.EntityId);
            if(image == null)
            {
                throw new ApplicationException("Could not upload image. Not found refernce for this entity in Images table.");
            }
            image.SetImageData(convertedSource, header);

            if (_dbContext.SaveChanges() == 0)
            {
                throw new Exception("Could not upload image to database.");
            }
        }
    }
}
