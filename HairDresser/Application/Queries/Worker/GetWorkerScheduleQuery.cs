using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.Worker
{
    public class GetWorkerScheduleQuery : IRequest<ScheduleDto>
    {
        public string Id { get; set; }
    }
}
