namespace lab3.Database.Configurations;

using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class DoctorDistrictConfiguration : IEntityTypeConfiguration<DoctorDistrict>
{
    public void Configure(EntityTypeBuilder<DoctorDistrict> builder)
    {
        builder.HasKey(e => new { e.DoctorId, e.DistrictId });

        builder.Property(e => e.DateOfStartWork)
            .IsRequired();

        builder.Property(e => e.DateOfEndWork)
            .IsRequired(false);

        builder.HasOne(dd => dd.Doctor)
            .WithMany(d => d.DoctorDistricts)
            .HasForeignKey(dd => dd.DoctorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(dd => dd.District)
            .WithMany(d => d.DoctorDistricts)
            .HasForeignKey(dd => dd.DistrictId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}