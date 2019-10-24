using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configuration
{
    public class WorkerConfiguration : IEntityTypeConfiguration<Worker>
    {
        public void Configure(EntityTypeBuilder<Worker> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasMany(w => w.Visits)
                   .WithOne(v => v.Worker)
                   .HasForeignKey(v => v.WorkerId);

            builder.HasMany(w => w.Opinions)
                   .WithOne(o => o.Worker)
                   .HasForeignKey(o => o.WorkerId);

            builder.Metadata.FindNavigation(nameof(Worker.Services))
                   .SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.Metadata.FindNavigation(nameof(Worker.Opinions))
                   .SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.Metadata.FindNavigation(nameof(Worker.Visits))
                   .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
