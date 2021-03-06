﻿using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities.ManyToMany;
using Domain.Enums;
using Domain.Exceptions;
using Domain.ValueObjects;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class Salon : EntityWithImage
    {
        private ISet<Service> _services = new HashSet<Service>();
        private ISet<Worker> _workers = new HashSet<Worker>();
        private ISet<ClientSalons> _clients = new HashSet<ClientSalons>();

        public Salon(IdentityUser admin, string name, Address address, Location location, string additionalInfo, SalonType type, Schedule schedule) : base(Guid.Parse(admin.Id))
        {
            Admin = admin;
            Name = name;
            Address = address;
            Location = location;
            Rating = -1.0f;
            AdditionalInfo = additionalInfo;
            Type = type;
            Schedule = new Schedule(Guid.Parse(admin.Id), schedule);
        }
        public Salon(IdentityUser admin, string name, Address address, Location location, string additionalInfo, SalonType type, Schedule schedule, byte[] imageSource, string imageHeader) : base(Guid.Parse(admin.Id), imageSource, imageHeader)
        {
            Admin = admin;
            Name = name;
            Address = address;
            Location = location;
            Rating = -1.0f;
            AdditionalInfo = additionalInfo;
            Type = type;
            Schedule = new Schedule(Guid.Parse(admin.Id), schedule);
        }
        private Salon()
        {

        }
        public IdentityUser Admin { get; private set; }
        public string Name { get; private set; }
        public Address Address { get; set; }
        public Location Location { get; set; }
        public float Rating { get; private set; }
        public string AdditionalInfo { get; private set; }
        public SalonType Type { get; private set; }
        public Schedule Schedule { get; set; }
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

        public bool UpdateData(string name, string additionalInfo, Address address, Location location, SalonType type)
        {
            var updated = false;
            if(Name != name)
            {
                Name = name;
                updated = true;
            }
            if (AdditionalInfo != additionalInfo)
            {
                AdditionalInfo = additionalInfo;
                updated = true;
            }
            if (Address != address)
            {
                Address = address;
                updated = true;
            }
            if (Location != location)
            {
                Location = location;
                updated = true;
            }
            if (Type != type)
            {
                Type = type;
                updated = true;
            }
            return updated;
        }

        public void UpdateRating()
        {
            float sum = 0;
            int workersWithRatingCount = 0;
            foreach(var worker in _workers)
            {
                if(worker.Rating != -1f)
                {
                    sum += worker.Rating;
                    workersWithRatingCount++;
                }
            }
            if (workersWithRatingCount > 0)
            {
                Rating = sum / (float)workersWithRatingCount;
            } 
            else
            {
                Rating = -1f;
            }
        }
    }
}
