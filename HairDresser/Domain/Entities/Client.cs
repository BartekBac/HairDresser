using Domain.Entities.ManyToMany;
using Domain.ValueObjects;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
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
    }
}
