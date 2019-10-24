using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Opinion : EntityWithImage
    {
        public Opinion(Guid clientId, Client client, Guid workerId, Worker worker, string description, float rate) : base(Guid.NewGuid())
        {
            ClientId = clientId;
            Client = client;
            WorkerId = workerId;
            Worker = worker;
            Description = description;
            Rate = rate;
        }
        public Opinion(Guid clientId, Client client, Guid workerId, Worker worker, string description, float rate, byte[] imageSource, string imageHeader) : base(Guid.NewGuid(), imageSource, imageHeader)
        {
            ClientId = clientId;
            Client = client;
            WorkerId = workerId;
            Worker = worker;
            Description = description;
            Rate = rate;
        }
        private Opinion()
        {

        }

        public Guid ClientId { get; private set; }
        public Client Client { get; private set; }
        public Guid WorkerId { get; private set; }
        public Worker Worker { get; private set; }
        public string Description { get; private set; }
        public float Rate { get; private set; }
    }
}
