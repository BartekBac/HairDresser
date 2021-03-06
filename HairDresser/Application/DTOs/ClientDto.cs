﻿using Domain.Entities;
using Domain.Entities.ManyToMany;
using Domain.Enums;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    public class ClientDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPhoneNumber { get; set; }
        public string ImageSource { get; set; }
        public IEnumerable<SalonDto> FavoriteSalons { get; set; }
        public IEnumerable<VisitDto> Visits { get; set; }
        public IEnumerable<OpinionDto> SendOpinions { get; set; }
    }
}
