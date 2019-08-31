﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ValueObjects
{
    public class EntityImage<T> : Entity
    {
        public Guid EntityId { get; set; }
        public T Entity { get; set; }
        public byte[] ImageData { get; set; }

        public EntityImage(Guid entityId, T entity)
        {
            EntityId = entityId;
            Entity = entity;
            ImageData = null;
        }
        public EntityImage(Guid entityId, T entity, byte[] imageData)
        {
            EntityId = entityId;
            Entity = entity;
            ImageData = imageData;
        }
    }
}
