using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.Salon
{
    public class GetSalonByIdQuery : IRequest<SalonDto>
    {
        public string Id { get; set; }
    }
}
