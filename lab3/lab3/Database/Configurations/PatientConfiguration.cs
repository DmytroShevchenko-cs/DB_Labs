namespace lab3.Database.Configurations;

using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.HasKey(e => e.PatientId);
        
        builder.Property(e => e.Address)
            .HasMaxLength(255);

        builder.Property(e => e.IsActive)
            .IsRequired();
        
        builder.HasOne(r => r.Card)
            .WithOne(r => r.Patient)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.Human)
            .WithOne(h => h.Patient)
            .HasForeignKey<Patient>(p => p.PatientId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}