using System;
using System.Collections.Generic;
using System.Text;
using Application.DTOs;
using MediatR;

namespace Application.Queries.Worker
{
    public class GetWorkerActiveVisitsQuery: IRequest<VisitDto[]>
    {
        public string Id { get; set; }
    }
}
