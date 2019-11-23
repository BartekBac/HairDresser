using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.Worker
{
    public class GetWorkerByIdQuery : IRequest<WorkerDto>
    {
        public string Id { get; set; }
    }
}
