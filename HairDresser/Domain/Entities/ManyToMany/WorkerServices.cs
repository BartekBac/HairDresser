using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.ManyToMany
{
    public class WorkerServices
    {
        public Guid WorkerId { get; set; }
        public Worker Worker { get; set; }
        public Guid ServiceId { get; set; }
        public Service Service { get; set; }
    }
}
