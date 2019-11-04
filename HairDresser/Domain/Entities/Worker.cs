using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Domain.ValueObjects;
using Domain.Entities.ManyToMany;
using Domain.Exceptions;

namespace Domain.Entities
{
    public class Worker : EntityWithImage
    {
        private ISet<WorkerServices> _services = new HashSet<WorkerServices>();
        private ISet<Opinion> _opinions = new HashSet<Opinion>();
        private ISet<Visit> _visits = new HashSet<Visit>();

        public Worker(IdentityUser user, string firstName, string lastName, Guid salonId, Schedule schedule): base(Guid.Parse(user.Id))
        {
            User = user;
            FirstName = firstName;
            LastName = lastName;
            SalonId = salonId;
            Rating = -1.0f;
            Schedule = new Schedule(Guid.Parse(user.Id), schedule);
        }
        public Worker(IdentityUser user, string firstName, string lastName, Guid salonId, Schedule schedule, byte[] imageSource, string imageHeader) : base(Guid.Parse(user.Id), imageSource, imageHeader)
        {
            User = user;
            FirstName = firstName;
            LastName = lastName;
            SalonId = salonId;
            Rating = -1.0f;
            Schedule = new Schedule(Guid.Parse(user.Id), schedule);
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

        public bool UpdateData(string firstName, string lastName)
        {
            var updated = false;
            if (FirstName != firstName)
            {
                this.FirstName = firstName;
                updated = true;
            }
            if (LastName != lastName)
            {
                this.LastName = lastName;
                updated = true;
            }
            return updated;
        }

        public void AssignService(Service service)
        {
            if(service == null || string.IsNullOrEmpty(service.Id.ToString()))
            {
                throw new DomainException("Could not assign null service.");
            }

            if(service.SalonId != this.SalonId)
            {
                throw new DomainException("Could not assign foreign salon's service.");
            }

            var alreadyAssignedService = _services.FirstOrDefault(s => s.ServiceId == service.Id);

            if(alreadyAssignedService == null)
            {
                _services.Add(new WorkerServices { WorkerId = Id, ServiceId = service.Id });
            }
        }

        public void ClearAssignedServices()
        {
            _services.Clear();
        }

    }
}
