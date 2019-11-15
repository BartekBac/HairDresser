using Application.Commands.Client;
using Domain.DbContexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Handlers.Client
{
    public class RemoveFavouriteSalonHandler : RequestHandler<RemoveFavouriteSalonCommand>
    {
        HairDresserDbContext _dbContext;
        public RemoveFavouriteSalonHandler(HairDresserDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        protected override void Handle(RemoveFavouriteSalonCommand request)
        {
            var client = _dbContext.Clients.Include(c => c.FavoriteSalons).FirstOrDefault(c => c.Id.ToString() == request.clientId);
            if (client == null)
            {
                throw new ApplicationException("Could not remove favourite salon. Not found refernce for client with id=" + request.clientId);
            }
            var salon = _dbContext.Salons.FirstOrDefault(s => s.Id.ToString() == request.salonId);
            if (salon == null)
            {
                throw new ApplicationException("Could not remove favourite salon. Not found refernce for salon with id=" + request.salonId);
            }

            if (client.RemoveFavouriteSalon(salon))
            {
                if (_dbContext.SaveChanges() == 0)
                {
                    throw new Exception("Could not remove favourite salon from client.");
                }
            }

        }
    }
}
