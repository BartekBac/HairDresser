using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.Salon
{
    public class GetAvailableSalonsQuery : IRequest<SalonDto[]>
    {
        public string clientId { get; set; }
    }
}
