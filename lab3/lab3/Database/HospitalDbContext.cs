namespace lab3.Database;

using Entities;
using Extensions;
using Microsoft.EntityFrameworkCore;

public class HospitalDbContext : DbContext
{
    public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options)
    { }

    public DbSet<Administrator> Administrators { get; set; }
    public DbSet<Card> Cards { get; set; }
    public DbSet<District> Districts { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<DoctorDistrict> DoctorDistricts { get; set; }
    public DbSet<Human> Humans { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Polyclinic> Polyclinics { get; set; }
    public DbSet<Schedule> Schedules { get; set; }
    public DbSet<Visit> Visits { get; set; }
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(HospitalDbContext).Assembly);
    }
}