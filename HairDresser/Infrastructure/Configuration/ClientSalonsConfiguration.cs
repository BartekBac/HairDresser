using Domain.Entities;
using Domain.Entities.ManyToMany;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class ClientSalonsConfiguration : IEntityTypeConfiguration<ClientSalons>
    {
        public void Configure(EntityTypeBuilder<ClientSalons> builder)
        {
            builder.HasKey(cs => new { cs.ClientId, cs.SalonId });

            builder.HasOne(cs => cs.Client)
                   .WithMany(c => c.FavoriteSalons)
                   .HasForeignKey(cs => cs.ClientId);

            builder.HasOne(cs => cs.Salon)
                   .WithMany(s => s.Clients)
                   .HasForeignKey(cs => cs.SalonId);
        }
    }
}
