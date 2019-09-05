
using Domain.Entities;
using Domain.Entities.ManyToMany;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configuration
{
    public class WorkerServicesConfiguration : IEntityTypeConfiguration<WorkerServices>
    {
        public void Configure(EntityTypeBuilder<WorkerServices> builder)
        {
            builder.HasKey(ws => new { ws.WorkerId, ws.ServiceId });

            builder.HasOne(ws => ws.Worker)
                   .WithMany(w => w.Services)
                   .HasForeignKey(ws => ws.WorkerId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(ws => ws.Service)
                   .WithMany(s => s.Workers)
                   .HasForeignKey(ws => ws.ServiceId);
        }
    }
}
