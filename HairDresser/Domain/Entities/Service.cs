using Domain.Entities.ManyToMany;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Service : Entity
    {
        private ISet<WorkerServices> _workers = new HashSet<WorkerServices>();
        private ISet<VisitServices> _visitsHistory = new HashSet<VisitServices>();

        public Service(string name, float price, int time, Guid salonId) : base()
        {
            Name = name;
            Price = price;
            Time = time;
            SalonId = salonId;
        }
        private Service()
        {

        }

        public string Name { get; private set; }
        public float Price { get; private set; }
        public int Time { get; private set; }
        public Guid SalonId { get; private set; }
        public Salon Salon { get; private set; }
        public IEnumerable<WorkerServices> Workers
        {
            get => _workers;
            set => _workers = new HashSet<WorkerServices>(value);
        }
        public IEnumerable<VisitServices> VisitsHistory
        {
            get => _visitsHistory;
            set => _visitsHistory = new HashSet<VisitServices>(value);
        }

        public bool Update(string name, float price, int time)
        {
            var updated = false;
            if(Name != name)
            {
                Name = name;
                updated = true;
            }
            if (Price != price)
            {
                Price = price;
                updated = true;
            }
            if (Time != time)
            {
                Time = time;
                updated = true;
            }
            return updated;
        }
    }
}
