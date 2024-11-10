namespace lab5.dataAccess.Database.Configurations;

using lab5.dataAccess.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class PolyclinicConfiguration : IEntityTypeConfiguration<Polyclinic>
{
    public void Configure(EntityTypeBuilder<Polyclinic> builder)
    {
        builder.HasKey(e => e.PolyclinicId);

        builder.Property(d => d.PolyclinicId)
            .ValueGeneratedOnAdd();
        
        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(e => e.Address)
            .HasMaxLength(255);
    }
}