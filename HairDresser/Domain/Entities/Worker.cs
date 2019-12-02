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
            RatingCount = 0;
            Schedule = new Schedule(Guid.Parse(user.Id), schedule);
        }
        public Worker(IdentityUser user, string firstName, string lastName, Guid salonId, Schedule schedule, byte[] imageSource, string imageHeader) : base(Guid.Parse(user.Id), imageSource, imageHeader)
        {
            User = user;
            FirstName = firstName;
            LastName = lastName;
            SalonId = salonId;
            Rating = -1.0f;
            RatingCount = 0;
            Schedule = new Schedule(Guid.Parse(user.Id), schedule);
        }
        private Worker()
        {

        }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public IdentityUser User { get; private set; }
        public float Rating { get; private set; }
        public int RatingCount { get; private set; }
        public Guid SalonId { get; private set; }
        public Salon Salon { get; set; }
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

        public void RemoveAssignedService(Service service)
        {
            if (service != null)
            {
                var alreadyAssignedService = _services.FirstOrDefault(s => s.ServiceId == service.Id);

                if (alreadyAssignedService != null)
                {
                    _services.Remove(alreadyAssignedService);
                }
            }
        }

        public void ClearAssignedServices()
        {
            _services.Clear();
        }

        public void UpdateRating(float newRating)
        {
            if(newRating < 0 || newRating > 5)
            {
                throw new DomainException("Rating value has to be in range from 0 to 5.");
            }
            if(Rating == -1)
            {
                Rating = newRating;
            } 
            else
            {
                Rating = ((Rating * (float)RatingCount) + newRating) / (float)(RatingCount + 1);
            }
            RatingCount++;
            Salon.UpdateRating();
        }

        public void RevertRating(float oldRating)
        {
            if (RatingCount == 0)
            {
                throw new DomainException("Worker with id=" + Id + " has already any opinion to remove");
            }
            if (RatingCount == 1)
            {
                Rating = -1f;
            }
            else
            {
                Rating = ((Rating * (float)RatingCount) - oldRating) / (float)(RatingCount - 1);
            }
            RatingCount--;
            Salon.UpdateRating();
        }

    }
}
