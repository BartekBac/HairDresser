using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class VisitConfiguration : IEntityTypeConfiguration<Visit>
    {
        public void Configure(EntityTypeBuilder<Visit> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Metadata.FindNavigation(nameof(Visit.Services))
                   .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
