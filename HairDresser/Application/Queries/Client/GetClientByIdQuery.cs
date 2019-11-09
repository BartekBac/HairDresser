using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.Client
{
    public class GetClientByIdQuery : IRequest<ClientDto>
    {
        public string Id { get; set; }
    }
}
