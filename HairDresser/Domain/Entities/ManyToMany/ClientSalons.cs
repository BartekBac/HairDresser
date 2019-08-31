using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.ManyToMany
{
    public class ClientSalons
    {
        public Guid ClientId { get; set; }
        public Client Client { get; set; }
        public Guid SalonId { get; set; }
        public Salon Salon { get; set; }
    }
}
