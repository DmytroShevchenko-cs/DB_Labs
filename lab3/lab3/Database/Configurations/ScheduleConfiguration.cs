namespace lab3.Database.Configurations;

using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
{
    public void Configure(EntityTypeBuilder<Schedule> builder)
    {
        builder.HasKey(e => e.ScheduleId);

        builder.Property(d => d.ScheduleId)
            .ValueGeneratedOnAdd();
        
        builder.Property(e => e.StartTime)
            .IsRequired();

        builder.Property(e => e.EndTime)
            .IsRequired();

        builder.Property(e => e.RoomNumber)
            .IsRequired();

        builder.HasOne(s => s.Doctor)
            .WithMany(d => d.Schedules)
            .HasForeignKey(s => s.DoctorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(s => s.District)
            .WithMany(d => d.Schedules)
            .HasForeignKey(s => s.DistrictId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}