using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configuration
{
    public class EntityImageConfiguration : IEntityTypeConfiguration<EntityImage<Client>>
    {
        public void Configure(EntityTypeBuilder<EntityImage<Client>> builder)
        {
            builder.HasKey(e => e.Id);

        }
    }
}
