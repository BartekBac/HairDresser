using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Domain.Entities;
using Domain.Configuration;
using Domain.Entities.ManyToMany;

namespace Domain.DbContexts
{
    public class HairDresserDbContext : IdentityDbContext
    {
        public HairDresserDbContext(DbContextOptions<HairDresserDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Opinion> Opinions { get; set; }
        public DbSet<Salon> Salons { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<ClientSalons> ClientSalons { get; set; }
        public DbSet<VisitServices> VisitServices { get; set; }
        public DbSet<WorkerServices> WorkerServices { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ClientConfiguration());
            builder.ApplyConfiguration(new ClientSalonsConfiguration());
            builder.ApplyConfiguration(new ImageConfiguration());
            builder.ApplyConfiguration(new OpinionConfiguration());
            builder.ApplyConfiguration(new SalonConfiguration());
            builder.ApplyConfiguration(new ScheduleConfiguration());
            builder.ApplyConfiguration(new ServiceConfiguration());
            builder.ApplyConfiguration(new VisitConfiguration());
            builder.ApplyConfiguration(new VisitServicesConfiguration());
            builder.ApplyConfiguration(new WorkerConfiguration());
            builder.ApplyConfiguration(new WorkerServicesConfiguration());

            base.OnModelCreating(builder);
        }
    }
}