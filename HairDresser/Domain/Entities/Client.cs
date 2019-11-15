using Domain.Entities.ManyToMany;
using Domain.Exceptions;
using Domain.ValueObjects;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class Client : EntityWithImage
    {
        private ISet<ClientSalons> _favoriteSalons = new HashSet<ClientSalons>();
        private ISet<Visit> _visits = new HashSet<Visit>();
        private ISet<Opinion> _sendOpinions = new HashSet<Opinion>();

        public Client(IdentityUser user, string firstName, string lastName) : base(Guid.Parse(user.Id))
        {
            User = user;
            FirstName = firstName;
            LastName = lastName;
        }

        public Client(IdentityUser user, string firstName, string lastName, byte[] imageSource, string imageHeade) : base(Guid.Parse(user.Id), imageSource, imageHeade)
        {
            User = user;
            FirstName = firstName;
            LastName = lastName;
        }
        private Client()
        {

        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public IdentityUser User { get; private set; }

        public IEnumerable<ClientSalons> FavoriteSalons
        {
            get => _favoriteSalons;
            set => _favoriteSalons = new HashSet<ClientSalons>(value);
        }
        public IEnumerable<Visit> Visits
        {
            get => _visits;
            set => _visits = new HashSet<Visit>(value);
        }
        public IEnumerable<Opinion> SendOpinions
        {
            get => _sendOpinions;
            set => _sendOpinions = new HashSet<Opinion>(value);
        }

        public bool AddFavouriteSalon(Salon salon)
        {
            bool updated = false;
            if (salon == null || string.IsNullOrEmpty(salon.Id.ToString()))
            {
                throw new DomainException("Could not add null salon.");
            }

            var alreadyAddedSalon = _favoriteSalons.FirstOrDefault(s => s.SalonId == salon.Id);

            if (alreadyAddedSalon == null)
            {
                _favoriteSalons.Add(new ClientSalons { ClientId = Id, SalonId = salon.Id });
                updated = true;
            }
            return updated;
        }

        public bool RemoveFavouriteSalon(Salon salon)
        {
            bool updated = false;
            if (salon == null || string.IsNullOrEmpty(salon.Id.ToString()))
            {
                throw new DomainException("Could not remove null salon.");
            }

            var alreadyAddedSalon = _favoriteSalons.FirstOrDefault(s => s.SalonId == salon.Id);

            if (alreadyAddedSalon != null)
            {
                _favoriteSalons.Remove(alreadyAddedSalon);
                updated = true;
            }
            return updated;
        }
    }
}
