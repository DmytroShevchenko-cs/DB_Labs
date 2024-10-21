namespace lab3.Database.Entities;

public class District
{
    public int DistrictId { get; set; }
    public int PolyclinicId { get; set; }
    public Polyclinic Polyclinic { get; set; } = null!;
    public string Name { get; set; } = null!;
    public int Floor { get; set; }
    
    public ICollection<DoctorDistrict> DoctorDistricts { get; set; } = null!;
    public ICollection<Schedule> Schedules { get; set; } = null!;
}