using Domain.Exceptions;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Opinion : EntityWithImage
    {
        public Opinion(Guid clientId, Guid workerId, string description, float rate) : base(Guid.NewGuid())
        {
            ClientId = clientId;
            WorkerId = workerId;
            Description = description;
            Rate = rate;
            Date = new DateTimeOffset(DateTime.Now).LocalDateTime;
            Answer = null;
        }
        public Opinion(Guid clientId, Guid workerId, string description, float rate, byte[] imageSource, string imageHeader) : base(Guid.NewGuid(), imageSource, imageHeader)
        {
            ClientId = clientId;
            WorkerId = workerId;
            Description = description;
            Rate = rate;
            Date = new DateTimeOffset(DateTime.Now).LocalDateTime;
            Answer = null;
        }
        private Opinion()
        {

        }

        public Guid ClientId { get; private set; }
        public Client Client { get; private set; }
        public Guid WorkerId { get; private set; }
        public Worker Worker { get; private set; }
        public string Description { get; private set; }
        public string Answer { get; private set; }
        public float Rate { get; private set; }
        public DateTime Date { get; private set; }

        public void SetAnswer(string answer)
        {
            Answer = answer;
        }
    }
}
