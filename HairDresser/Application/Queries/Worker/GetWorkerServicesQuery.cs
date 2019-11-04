using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.Worker
{
    public class GetWorkerServicesQuery : IRequest<ServiceDto[]>
    {
        public string Id { get; set; }
    }
}
