using Application.DTOs;
using Application.Queries.Salon;
using Domain.DbContexts;
using MediatR;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Application.Services;

namespace Application.Handlers.Salon
{
    public class GetSalonByIdHandler : RequestHandler<GetSalonByIdQuery, SalonDto>
    {
        private HairDresserDbContext _dbContext;
        private IMapper _mapper;

        public GetSalonByIdHandler(HairDresserDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        protected override SalonDto Handle(GetSalonByIdQuery request)
        {
            Guid salonId = new Guid(request.Id.ToString());

            var salon = _dbContext.Salons
                .Include(s => s.Admin)
                .Include(s => s.Services)
                .Include(s => s.Workers).ThenInclude(w => w.User)
                .Include(s => s.Workers).ThenInclude(w => w.Services)
                .Include(s => s.Workers).ThenInclude(w => w.Opinions).ThenInclude(o => o.Client).ThenInclude(c => c.User)
                .FirstOrDefault(s => s.Id == salonId);
            var image = _dbContext.Images.FirstOrDefault(i => i.Id == salonId);
            var schedule = _dbContext.Schedules.FirstOrDefault(i => i.Id == salonId);
            salon.Image = image;
            salon.Schedule = schedule;
            if (salon == null)
            {
                throw new ApplicationException("Could not find salon with id=" + salonId);
            }
            if (image == null)
            {
                throw new ApplicationException("Could not find image for salon with id=" + salonId);
            }
            if (schedule == null)
            {
                throw new ApplicationException("Could not find schedule for salon with id=" + salonId);
            }

            foreach (var worker in salon.Workers)
            {
                var workerImage = _dbContext.Images.FirstOrDefault(i => i.Id == worker.Id);
                var workerSchedule = _dbContext.Schedules.FirstOrDefault(s => s.Id == worker.Id);
                worker.Image = workerImage;
                worker.Schedule = workerSchedule;

                foreach (var opinion in worker.Opinions)
                {
                    var opinionImage = _dbContext.Images.FirstOrDefault(i => i.Id == opinion.Id);
                    opinion.Image = opinionImage;
                }
            }

            var result = _mapper.Map<SalonDto>(salon);

            /*result.Workers = salon.Workers.Join(
                _dbContext.Images.AsEnumerable(),
                worker => worker.Id,
                image => image.Id,
                (worker, image) => new WorkerDto
                {
                    Id = worker.Id.ToString(),
                    FirstName = worker.FirstName,
                    LastName = worker.LastName,
                    Rating = worker.Rating,
                    Schedule = null,
                    Services = _mapper.Map<ServiceDto[]>(worker.Services),
                    UserEmail = worker.User.Email,
                    UserPhoneNumber = worker.User.PhoneNumber,
                    UserName = worker.User.UserName,
                    ImageSource = ImageService.ConcatenateToString(image)
                }).Join(
                    _dbContext.Schedules.AsEnumerable(),
                    worker => worker.Id,
                    schedule => schedule.Id.ToString(),
                    (worker, schedule) => new WorkerDto
                    {
                        Id = worker.Id,
                        FirstName = worker.FirstName,
                        LastName = worker.LastName,
                        Rating = worker.Rating,
                        Schedule = _mapper.Map<ScheduleDto>(schedule),
                        Services = worker.Services,
                        UserEmail = worker.UserEmail,
                        UserPhoneNumber = worker.UserPhoneNumber,
                        UserName = worker.UserName,
                        ImageSource = worker.ImageSource
                    });*/
            return result;
        }
    }
}
