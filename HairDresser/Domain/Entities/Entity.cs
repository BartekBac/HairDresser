using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; } = Guid.NewGuid();

        protected Entity() {}

        protected Entity(Guid id)
        {
            Id = id;
        }
    }
}
