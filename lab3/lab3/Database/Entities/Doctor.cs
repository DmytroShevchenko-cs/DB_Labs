namespace lab3.Database.Entities;

public class Doctor
{
    public int DoctorId { get; set; }
    public Human Human { get; set; }
    public string Category { get; set; }
    public int Experience { get; set; }
    public bool IsActive { get; set; }

    public ICollection<DoctorDistrict> DoctorDistricts { get; set; }
    public ICollection<Schedule> Schedules { get; set; }
}