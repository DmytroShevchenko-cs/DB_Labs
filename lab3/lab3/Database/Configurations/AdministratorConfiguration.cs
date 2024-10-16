namespace lab3.Database.Configurations;

using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class AdministratorConfiguration : IEntityTypeConfiguration<Administrator>
{
    public void Configure(EntityTypeBuilder<Administrator> builder)
    {
        builder.HasKey(e => e.AdministratorId);
        
        builder.HasOne(d => d.Human)
            .WithOne(h => h.Administrator)
            .HasForeignKey<Administrator>(d => d.AdministratorId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}