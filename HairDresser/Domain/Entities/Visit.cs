using Domain.Entities.ManyToMany;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Visit : Entity
    {
        private ISet<VisitServices> _services = new HashSet<VisitServices>();

        public Visit(Guid clientId, Guid workerId, Service[] services, DateTime term, int totalTime, float totalPrice) : base()
        {
            ClientId = clientId;
            WorkerId = workerId;
            Status = VisitStatus.Pending;
            Term = term;
            TotalTime = totalTime;
            TotalPrice = totalPrice;
            Info = "";
            OpinionSent = false;
            foreach (var service in services)
            {
                if (service != null)
                {
                    _services.Add(new VisitServices { VisitId = Id, ServiceId = service.Id });
                }
            }
        }
        private Visit()
        {

        }
        public Guid ClientId { get; private set; }
        public Client Client { get; private set; }
        public Guid WorkerId { get; private set; }
        public Worker Worker { get; private set; }
        public IEnumerable<VisitServices> Services
        {
            get => _services;
            set => _services = new HashSet<VisitServices>(value);
        }
        public VisitStatus Status { get; private set; }
        public DateTime Term { get; private set; }
        public int TotalTime { get; private set; }
        public float TotalPrice { get; private set; }
        public string Info { get; private set; }
        public bool OpinionSent { get; private set; }

        public void SetTerm(DateTime term)
        {
            Term = term;
        }
        public void SetStatus(VisitStatus status)
        {
            Status = status;
        }
        public void SetInfo(string info)
        {
            Info = info;
        }
        public void SetOpinionSent(bool opinionSent)
        {
            OpinionSent = opinionSent;
        }
    }
}
