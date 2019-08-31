using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configuration
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(c => c.Image)
                   .WithOne(ei => ei.Entity)
                   .HasForeignKey<EntityImage<Client>>(ei => ei.EntityId);

            builder.HasMany(c => c.Visits)
                   .WithOne(v => v.Client)
                   .HasForeignKey(v => v.ClientId);

            builder.Metadata.FindNavigation(nameof(Client.Visits))
                   .SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.Metadata.FindNavigation(nameof(Client.FavoriteSalons))
                   .SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.Metadata.FindNavigation(nameof(Client.SendOpinions))
                   .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
