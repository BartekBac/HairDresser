using Domain.Entities;
using Domain.Entities.ManyToMany;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class VisitServicesConfiguration : IEntityTypeConfiguration<VisitServices>
    {
        public void Configure(EntityTypeBuilder<VisitServices> builder)
        {
            builder.HasKey(vs => new { vs.VisitId, vs.ServiceId });

            builder.HasOne(vs => vs.Visit)
                   .WithMany(v => v.Services)
                   .HasForeignKey(vs => vs.VisitId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(vs => vs.Service)
                   .WithMany(s => s.VisitsHistory)
                   .HasForeignKey(vs => vs.ServiceId);
        }
    }
}
