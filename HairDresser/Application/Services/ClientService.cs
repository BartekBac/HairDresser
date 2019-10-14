using Application.DTOs;
using AutoMapper;
using Domain.DbContexts;
using Domain.Entities;
using Domain.Exceptions;
using Domain.ValueObjects;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Application.Services
{
    public class ClientService : IClientService
    {
        HairDresserDbContext _dbContext;
        IMapper _mapper;

        public ClientService(HairDresserDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public ClientDto CreateClient(ClientCreationDto clientCreation, IdentityUser user)
        {
            var existingClient = _dbContext.Clients.FirstOrDefault(s => s.Id.ToString() == user.Id);

            if(existingClient != null)
            {
                throw new ApplicationException("Client for user [id=" + user.Id + "] already exists");
            }

            var client = new Client(user, clientCreation.FirstName, clientCreation.LastName);

            _dbContext.Clients.Add(client);

            if (_dbContext.SaveChanges() == 0)
            {
                throw new DomainException("Could not save Client into database.");
            }

            return _mapper.Map<ClientDto>(client);
        }
    }
}
