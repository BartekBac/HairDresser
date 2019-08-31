using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configuration
{
    public class OpinionConfiguration : IEntityTypeConfiguration<Opinion>
    {
        public void Configure(EntityTypeBuilder<Opinion> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(o => o.Image)
                   .WithOne(ei => ei.Entity)
                   .HasForeignKey<EntityImage<Opinion>>(ei => ei.EntityId);
        }
    }
}
