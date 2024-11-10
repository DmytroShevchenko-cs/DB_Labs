namespace lab5.dataAccess.Database.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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