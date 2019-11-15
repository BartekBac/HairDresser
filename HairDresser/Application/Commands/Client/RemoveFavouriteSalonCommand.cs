using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.Client
{
    public class RemoveFavouriteSalonCommand : IRequest
    {
        public string clientId { get; set; }
        public string salonId { get; set; }
    }
}
