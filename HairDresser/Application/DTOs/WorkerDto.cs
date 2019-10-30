﻿using Domain.Enums;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    public class WorkerDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public float Rating { get; set; }
        public ScheduleDto Schedule { get; set; }
        public string UserPhoneNumber { get; set; }
        public string UserEmail { get; set; }
        public string ImageSource  { get; set; }
    }
}
