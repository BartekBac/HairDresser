using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    public class OpinionDto
    {
        public string Id { get; set; }
        public string ClientId { get; set; }
        public string ClientFirstName { get; set; }
        public string ClientLastName { get; set; }
        public string ClientEmail { get; set; }
        public string ClientPhoneNumber { get; set; }
        public string WorkerId { get; set; }
        public string WorkerFirstName { get; set; }
        public string WorkerLastName { get; set; }
        public string Description { get; set; }
        public float Rate { get; set; }
        public DateTime Date { get; set; }
        public string ImageSource { get; set; }
    }
}
