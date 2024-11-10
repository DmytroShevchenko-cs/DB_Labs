namespace lab5.dataAccess.Database.Configurations;

using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class DistrictConfiguration : IEntityTypeConfiguration<District>
{
    public void Configure(EntityTypeBuilder<District> builder)
    {
        builder.HasKey(e => e.DistrictId);

        builder.Property(d => d.DistrictId)
            .ValueGeneratedOnAdd();
        
        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(e => e.Floor)
            .IsRequired();

        builder.HasOne(d => d.Polyclinic)
            .WithMany(p => p.Districts)
            .HasForeignKey(d => d.PolyclinicId)
            .OnDelete(DeleteBehavior.Restrict);

    }
}