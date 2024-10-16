namespace lab3.Database.Configurations;

using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class HumanConfiguration : IEntityTypeConfiguration<Human>
{
    public void Configure(EntityTypeBuilder<Human> builder)
    {
        builder.HasKey(e => e.HumanId);

        builder.Property(d => d.HumanId)
            .ValueGeneratedOnAdd();
        
        builder.Property(e => e.FirstName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.LastName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.MiddleName)
            .HasMaxLength(50);

        builder.Property(e => e.Gender)
            .IsRequired();

        builder.Property(e => e.Age)
            .IsRequired();

        builder.Property(e => e.DateOfBirth)
            .IsRequired();
    }
}