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

            builder.HasOne(w => w.Image)
                   .WithOne(ei => ei.Entity)
                   .HasForeignKey<EntityImage<Worker>>(ei => ei.EntityId);

            builder.HasMany(w => w.Visits)
                   .WithOne(v => v.Worker)
                   .HasForeignKey(v => v.WorkerId);

            builder.HasMany(w => w.Opinions)
                   .WithOne(o => o.Worker)
                   .HasForeignKey(o => o.WorkerId);

            builder.OwnsOne(w => w.Schedule, schedule =>
            {
                schedule.OwnsOne(s => s.Monday, day =>
                {
                    day.OwnsOne(d => d.Begin, dayTime => 
                    {
                        dayTime.Property(dt => dt.Hour).HasColumnName("ScheduleModayBeginHour");
                        dayTime.Property(dt => dt.Minute).HasColumnName("ScheduleModayBeginMinute");
                    });
                    day.OwnsOne(d => d.End, dayTime =>
                    {
                        dayTime.Property(dt => dt.Hour).HasColumnName("ScheduleModayEndHour");
                        dayTime.Property(dt => dt.Minute).HasColumnName("ScheduleModayEndMinute");
                    });
                });
                schedule.OwnsOne(s => s.Tuesday, day =>
                {
                    day.OwnsOne(d => d.Begin, dayTime =>
                    {
                        dayTime.Property(dt => dt.Hour).HasColumnName("ScheduleTuesdayBeginHour");
                        dayTime.Property(dt => dt.Minute).HasColumnName("ScheduleTuesdayBeginMinute");
                    });
                    day.OwnsOne(d => d.End, dayTime =>
                    {
                        dayTime.Property(dt => dt.Hour).HasColumnName("ScheduleTuesdayEndHour");
                        dayTime.Property(dt => dt.Minute).HasColumnName("ScheduleTuesdayEndMinute");
                    });
                });
                schedule.OwnsOne(s => s.Wednesday, day =>
                {
                    day.OwnsOne(d => d.Begin, dayTime =>
                    {
                        dayTime.Property(dt => dt.Hour).HasColumnName("ScheduleWednesdayBeginHour");
                        dayTime.Property(dt => dt.Minute).HasColumnName("ScheduleWednesdayBeginMinute");
                    });
                    day.OwnsOne(d => d.End, dayTime =>
                    {
                        dayTime.Property(dt => dt.Hour).HasColumnName("ScheduleWednesdayEndHour");
                        dayTime.Property(dt => dt.Minute).HasColumnName("ScheduleWednesdayEndMinute");
                    });
                });
                schedule.OwnsOne(s => s.Thursday, day =>
                {
                    day.OwnsOne(d => d.Begin, dayTime =>
                    {
                        dayTime.Property(dt => dt.Hour).HasColumnName("ScheduleThursdayBeginHour");
                        dayTime.Property(dt => dt.Minute).HasColumnName("ScheduleThursdayBeginMinute");
                    });
                    day.OwnsOne(d => d.End, dayTime =>
                    {
                        dayTime.Property(dt => dt.Hour).HasColumnName("ScheduleThursdayEndHour");
                        dayTime.Property(dt => dt.Minute).HasColumnName("ScheduleThursdayEndMinute");
                    });
                });
                schedule.OwnsOne(s => s.Friday, day =>
                {
                    day.OwnsOne(d => d.Begin, dayTime =>
                    {
                        dayTime.Property(dt => dt.Hour).HasColumnName("ScheduleFridayBeginHour");
                        dayTime.Property(dt => dt.Minute).HasColumnName("ScheduleFridayBeginMinute");
                    });
                    day.OwnsOne(d => d.End, dayTime =>
                    {
                        dayTime.Property(dt => dt.Hour).HasColumnName("ScheduleFridayEndHour");
                        dayTime.Property(dt => dt.Minute).HasColumnName("ScheduleFridayEndMinute");
                    });
                });
                schedule.OwnsOne(s => s.Saturday, day =>
                {
                    day.OwnsOne(d => d.Begin, dayTime =>
                    {
                        dayTime.Property(dt => dt.Hour).HasColumnName("ScheduleSaturdayBeginHour");
                        dayTime.Property(dt => dt.Minute).HasColumnName("ScheduleSaturdayBeginMinute");
                    });
                    day.OwnsOne(d => d.End, dayTime =>
                    {
                        dayTime.Property(dt => dt.Hour).HasColumnName("ScheduleSaturdayEndHour");
                        dayTime.Property(dt => dt.Minute).HasColumnName("ScheduleSaturdayEndMinute");
                    });
                });
                schedule.OwnsOne(s => s.Sunday, day =>
                {
                    day.OwnsOne(d => d.Begin, dayTime =>
                    {
                        dayTime.Property(dt => dt.Hour).HasColumnName("ScheduleSundayBeginHour");
                        dayTime.Property(dt => dt.Minute).HasColumnName("ScheduleSundayBeginMinute");
                    });
                    day.OwnsOne(d => d.End, dayTime =>
                    {
                        dayTime.Property(dt => dt.Hour).HasColumnName("ScheduleSundayEndHour");
                        dayTime.Property(dt => dt.Minute).HasColumnName("ScheduleSundayEndMinute");
                    });
                });
            });

            builder.Metadata.FindNavigation(nameof(Worker.Services))
                   .SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.Metadata.FindNavigation(nameof(Worker.Opinions))
                   .SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.Metadata.FindNavigation(nameof(Worker.Visits))
                   .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
