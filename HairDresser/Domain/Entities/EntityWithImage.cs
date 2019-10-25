using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public abstract class EntityWithImage : Entity
    {
        public Image Image { get; set; }

        protected EntityWithImage() {}

        protected EntityWithImage(Guid id) : base(id)
        {
            Image = new Image(Id);
        }
        protected EntityWithImage(Guid id, byte[] imageSource, string imageHeader) : base(id)
        {
            Image = new Image(Id, imageSource, imageHeader);
        }
    }
}
