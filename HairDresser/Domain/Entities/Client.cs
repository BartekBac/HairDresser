using Domain.Entities.ManyToMany;
using Domain.ValueObjects;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Client : Entity
    {
        private ISet<ClientSalons> _favoriteSalons = new HashSet<ClientSalons>();
        private ISet<Visit> _visits = new HashSet<Visit>();
        private ISet<Opinion> _sendOpinions = new HashSet<Opinion>();

        public Client(IdentityUser user, string firstName, string lastName) : base(Guid.Parse(user.Id))
        {
            User = user;
            FirstName = firstName;
            LastName = lastName;
            Image = new EntityImage<Client>(Id, this);
        }

        public Client(IdentityUser user, string firstName, string lastName, byte[] imageData) : base(Guid.Parse(user.Id))
        {
            User = user;
            FirstName = firstName;
            LastName = lastName;
            Image = new EntityImage<Client>(Id, this, imageData);
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public IdentityUser User { get; private set; }
        public EntityImage<Client> Image { get; set; }

        public IEnumerable<ClientSalons> FavoriteSalons
        {
            get => _favoriteSalons;
            set => _favoriteSalons = new HashSet<ClientSalons>(value);
        }
        public IEnumerable<Visit> Visits
        {
            //get => _visits.Where(v => v.Status == VisitStatus.Accepted); // TODO: sprawdzić czy coś takiego będzie działać a jak nie to ma być w serwisie
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
