using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities.ManyToMany;
using Domain.Enums;
using Domain.ValueObjects;
using Domain.ValueObjects.Schedule;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class Salon : Entity
    {
        private ISet<Service> _services = new HashSet<Service>();
        private ISet<Worker> _workers = new HashSet<Worker>();
        private ISet<ClientSalons> _clients = new HashSet<ClientSalons>();

        public Salon(IdentityUser admin, string name, Address address, string additionalInfo, SalonType type) : base(Guid.Parse(admin.Id))
        {
            Admin = admin;
            Name = name;
            Address = address;
            Rating = -1.0f;
            AdditionalInfo = additionalInfo;
            Type = type;
            Image = new EntityImage<Salon>(Id, this);
            Schedule = new Schedule(new TimeSpan(0, 0, 0), new TimeSpan(23, 59, 0));
        }
        public Salon(IdentityUser admin, string name, Address address, string additionalInfo, SalonType type, byte[] imageData) : base(Guid.Parse(admin.Id))
        {
            Admin = admin;
            Name = name;
            Address = address;
            Rating = -1.0f;
            AdditionalInfo = additionalInfo;
            Type = type;
            Image = new EntityImage<Salon>(Id, this, imageData);
            Schedule = new Schedule(new TimeSpan(0, 0, 0), new TimeSpan(23, 59, 0));
        }
        private Salon()
        {

        }
        public IdentityUser Admin { get; private set; }
        public string Name { get; private set; }
        public Address Address { get; set; }
        public float Rating { get; private set; }
        public string AdditionalInfo { get; private set; }
        public SalonType Type { get; private set; }
        public Schedule Schedule { get; set; }
        public EntityImage<Salon> Image { get; set; }
        public IEnumerable<Service> Services
        {
            get => _services;
            set => _services = new HashSet<Service>(value);
        }
        public IEnumerable<Worker> Workers
        {
            get => _workers;
            set => _workers = new HashSet<Worker>(value);
        }
        public IEnumerable<ClientSalons> Clients
        {
            get => _clients;
            set => _clients = new HashSet<ClientSalons>(value);
        }
    }
}
