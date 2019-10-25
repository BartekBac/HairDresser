using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configuration
{
    public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.HasKey(e => e.Id);

            builder.OwnsOne(s => s.Monday);
            builder.OwnsOne(s => s.Tuesday);
            builder.OwnsOne(s => s.Wednesday);
            builder.OwnsOne(s => s.Thursday);
            builder.OwnsOne(s => s.Friday);
            builder.OwnsOne(s => s.Saturday);
            builder.OwnsOne(s => s.Sunday);
        }
    }
}
