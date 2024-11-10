namespace lab5.dataAccess.Database.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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