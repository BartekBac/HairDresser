using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    public class VisitDto
    {
        public string Id { get; set; }
        public string ClientId { get; set; }
        public string ClientFirstName { get; set; }
        public string ClientLastName { get; set; }
        public string ClientUserName { get; set; }
        public string ClientEmail { get; set; }
        public string ClientPhoneNumber { get; set; }
        public string WorkerId { get; set; }
        public string WorkerFirstName { get; set; }
        public string WorkerLastName { get; set; }
        public float WorkerRating { get; set; }
        public string WorkerPhoneNumber { get; set; }
        public string WorkerEmail { get; set; }
        public string WorkerUserName { get; set; }
        public IEnumerable<ServiceDto> Services { get; set; }
        public VisitStatus Status { get; set; }
        public DateTime Term { get; set; }
        public int TotalTime { get; set; }
        public float TotalPrice { get; set; }
        public string Info { get; set; }
        public bool OpinionSent { get; set; }
    }
}
