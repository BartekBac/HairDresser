using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Opinion : Entity
    {
        public Opinion(Guid clientId, Client client, Guid workerId, Worker worker, string description, float rate) : base()
        {
            ClientId = clientId;
            Client = client;
            WorkerId = workerId;
            Worker = worker;
            Description = description;
            Rate = rate;
            Image = new EntityImage<Opinion>(Id, this);
        }
        public Opinion(Guid clientId, Client client, Guid workerId, Worker worker, string description, float rate, byte[] imageData) : base()
        {
            ClientId = clientId;
            Client = client;
            WorkerId = workerId;
            Worker = worker;
            Description = description;
            Rate = rate;
            Image = new EntityImage<Opinion>(Id, this, imageData);
        }

        public Guid ClientId { get; private set; }
        public Client Client { get; private set; }
        public Guid WorkerId { get; private set; }
        public Worker Worker { get; private set; }
        public string Description { get; private set; }
        public float Rate { get; private set; }
        public EntityImage<Opinion> Image { get; private set; }
    }
}
