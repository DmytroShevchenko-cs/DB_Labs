namespace lab3.Database.Configurations;

using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class VisitConfiguration : IEntityTypeConfiguration<Visit>
{
    public void Configure(EntityTypeBuilder<Visit> builder)
    {
        builder.HasKey(e => e.VisitId);
        
        builder.Property(d => d.VisitId)
            .ValueGeneratedOnAdd();

        builder.Property(e => e.VisitDate)
            .IsRequired();

        builder.Property(e => e.Diagnosis)
            .HasMaxLength(255);

        builder.Property(e => e.Prescriptions)
            .HasMaxLength(255);
        
        builder.HasOne(v => v.Patient)
            .WithMany(p => p.Visits)
            .HasForeignKey(v => v.PatientId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(v => v.Schedule)
            .WithMany(s => s.Visits)
            .HasForeignKey(v => v.ScheduleId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}