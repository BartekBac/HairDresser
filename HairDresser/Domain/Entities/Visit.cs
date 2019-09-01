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

        public Visit(Guid clientId, Client client, Guid workerId, Worker worker, ISet<VisitServices> services, DateTime term, int totalTime) : base()
        {
            ClientId = clientId;
            Client = client;
            WorkerId = workerId;
            Worker = worker;
            _services = services;
            Status = VisitStatus.Pending;
            Term = term;
            TotalTime = totalTime;
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
    }
}
