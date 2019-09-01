using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Domain.ValueObjects;
using Domain.ValueObjects.Schedule;
using Domain.Entities.ManyToMany;

namespace Domain.Entities
{
    public class Worker : Entity
    {
        private ISet<WorkerServices> _services = new HashSet<WorkerServices>();
        private ISet<Opinion> _opinions = new HashSet<Opinion>();
        private ISet<Visit> _visits = new HashSet<Visit>();

        public Worker(IdentityUser user, string firstName, string lastName, Guid salonId): base(Guid.Parse(user.Id))
        {
            User = user;
            FirstName = firstName;
            LastName = lastName;
            SalonId = salonId;
            Rating = -1.0f;
            Image = new EntityImage<Worker>(Id, this);
            Schedule = new Schedule(new TimeSpan(0, 0, 0), new TimeSpan(23, 59, 0));
        }
        public Worker(IdentityUser user, string firstName, string lastName, Guid salonId, Salon salon, byte[] imageData) : base(Guid.Parse(user.Id))
        {
            User = user;
            FirstName = firstName;
            LastName = lastName;
            SalonId = salonId;
            Salon = salon;
            Rating = -1.0f;
            Image = new EntityImage<Worker>(Id, this, imageData);
            Schedule = new Schedule(new TimeSpan(0, 0, 0), new TimeSpan(23, 59, 0));
        }
        private Worker()
        {

        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public IdentityUser User { get; private set; }
        public float Rating { get; private set; }
        public Guid SalonId { get; private set; }
        public Salon Salon { get; private set; }
        public Schedule Schedule { get; set; }
        public EntityImage<Worker> Image { get; set; }
        public IEnumerable<WorkerServices> Services
        {
            get => _services;
            set => _services = new HashSet<WorkerServices>(value);
        }
        public IEnumerable<Opinion> Opinions
        {
            get => _opinions;
            set => _opinions = new HashSet<Opinion>(value);
        }
        public IEnumerable<Visit> Visits
        {
            //get => _visits.Where(v => v.Status == VisitStatus.Accepted); // TODO: sprawdzić czy coś takiego będzie działać a jak nie to ma być w serwisie
            get => _visits;
            set => _visits = new HashSet<Visit>(value);
        }

    }
}
