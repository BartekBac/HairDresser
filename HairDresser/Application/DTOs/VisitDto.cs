using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    public class VisitDto
    {
        public string Id { get; set; }
        public ClientDto Client { get; set; }
        public WorkerDto Worker { get; set; }
        public IEnumerable<ServiceDto> Services { get; set; }
        public VisitStatus Status { get; set; }
        public DateTime Term { get; set; }
        public int TotalTime { get; set; }
        public float TotalPrice { get; set; }
        public string Info { get; set; }
    }
}
