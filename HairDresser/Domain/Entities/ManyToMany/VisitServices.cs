using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.ManyToMany
{
    public class VisitServices
    {
        public Guid VisitId { get; set; }
        public Visit Visit { get; set; }
        public Guid ServiceId { get; set; }
        public Service Service { get; set; }
    }
}
