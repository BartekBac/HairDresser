using System;
using System.Collections.Generic;
using System.Text;
using Application.DTOs;
using MediatR;

namespace Application.Queries.Salon
{
    public class GetSalonsQuery : IRequest<SalonDto[]>
    {

    }
}
