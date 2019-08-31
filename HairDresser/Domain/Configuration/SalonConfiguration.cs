using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configuration
{
    public class SalonConfiguration : IEntityTypeConfiguration<Salon>
    {
        public void Configure(EntityTypeBuilder<Salon> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(s => s.Image)
                   .WithOne(ei => ei.Entity)
                   .HasForeignKey<EntityImage<Salon>>(ei => ei.EntityId);

            builder.HasMany(s => s.Services)
                   .WithOne(s => s.Salon)
                   .HasForeignKey(s => s.SalonId);

            builder.HasMany(s => s.Workers)
                   .WithOne(w => w.Salon)
                   .HasForeignKey(w => w.SalonId);

            builder.OwnsOne(s => s.Address);

            builder.OwnsOne(s => s.Schedule);

            builder.Metadata.FindNavigation(nameof(Salon.Services))
                   .SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.Metadata.FindNavigation(nameof(Salon.Workers))
                   .SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.Metadata.FindNavigation(nameof(Salon.Clients))
                   .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
