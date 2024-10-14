namespace lab3.Database.Entities;

public class District
{
    public int DistrictId { get; set; }
    public int PolyclinicId { get; set; }
    public Polyclinic Polyclinic { get; set; }
    public string Name { get; set; }
    public int Floor { get; set; }
    
    public ICollection<DoctorDistrict> DoctorDistricts { get; set; }
    public ICollection<Schedule> Schedules { get; set; }
}