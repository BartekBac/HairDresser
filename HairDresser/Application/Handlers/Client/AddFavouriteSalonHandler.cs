using Application.Commands.Client;
using Infrastructure.DbContexts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Client
{
    public class AddFavouriteSalonHandler : RequestHandler<AddFavouriteSalonCommand>
    {
        HairDresserDbContext _dbContext;
        public AddFavouriteSalonHandler(HairDresserDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        protected override void Handle(AddFavouriteSalonCommand request)
        {
            var client = _dbContext.Clients.Include(c => c.FavoriteSalons).FirstOrDefault(c => c.Id.ToString() == request.clientId);
            if (client == null)
            {
                throw new ApplicationException("Could not add favourite salon. Not found refernce for client with id="+request.clientId);
            }
            var salon = _dbContext.Salons.FirstOrDefault(s => s.Id.ToString() == request.salonId);
            if (salon == null)
            {
                throw new ApplicationException("Could not add favourite salon. Not found refernce for salon with id="+request.salonId);
            }

            if (client.AddFavouriteSalon(salon))
            {
                if (_dbContext.SaveChanges() == 0)
                {
                    throw new Exception("Could not add favourite salon to client.");
                }
            }

        }
    }
}
