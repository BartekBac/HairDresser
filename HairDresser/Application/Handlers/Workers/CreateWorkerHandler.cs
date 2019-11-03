using Application.Commands.Workers;
using Application.Services;
using Domain.DbContexts;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Domain.Entities;
using AutoMapper;
using Application.DTOs;

namespace Application.Handlers.Workers
{
    public class CreateWorkerHandler : AsyncRequestHandler<CreateWorkerCommand>
    {
        HairDresserDbContext _dbContext;
        IUserService _userService;
        UserManager<IdentityUser> _userManager;
        IMapper _mapper;


        public CreateWorkerHandler(
            HairDresserDbContext dbContext,
            IUserService userService,
            UserManager<IdentityUser> userManager,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _userService = userService;
            _userManager = userManager;
            _mapper = mapper;
        }
        protected override async Task Handle(CreateWorkerCommand request, CancellationToken cancellationToken)
        {
            var user = await _userService.CreateUserAsync(request.UserData);
            var identityUser = await _userManager.FindByIdAsync(user.Id);
            var resolvedImage = ImageService.ResolveToImage(request.ImageData);

            var worker = new Worker(
                identityUser,
                request.FirstName,
                request.LastName,
                new Guid(request.SalonId),
                _mapper.Map<Schedule>(request.Schedule),
                resolvedImage.Source,
                resolvedImage.Header);

            _dbContext.Workers.Add(worker);

            if (_dbContext.SaveChanges() == 0)
            {
                throw new Exception("Could not save created worker into database.");
            }
        }
    }
}
