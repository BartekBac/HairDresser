using Application.Commands;
using Domain.DbContexts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Application.Services;

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
            var resolvedImage = ImageService.ResolveToImage(request.ImageSource);
            var image = _dbContext.Images.FirstOrDefault(i => i.Id == new Guid(request.Id));
            if(image == null)
            {
                throw new ApplicationException("Could not upload image. Not found refernce for this entity in Images table.");
            }
            if (image.Update(resolvedImage.Source, resolvedImage.Header))
            {
                if (_dbContext.SaveChanges() == 0)
                {
                    throw new Exception("Could not save image into database.");
                }
            }
        }
    }
}
