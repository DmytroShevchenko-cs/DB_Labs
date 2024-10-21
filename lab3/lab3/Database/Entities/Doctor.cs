namespace lab3.Database.Entities;

public class Doctor
{
    public int DoctorId { get; set; }
    public Human Human { get; set; } = null!;
    public string Category { get; set; } = null!;
    public int Experience { get; set; }
    public bool IsActive { get; set; }

    public ICollection<DoctorDistrict> DoctorDistricts { get; set; } = null!;
    public ICollection<Schedule> Schedules { get; set; } = null!;
}