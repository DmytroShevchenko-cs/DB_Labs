namespace lab5.dataAccess.Database.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class DoctorDistrict
{
    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; } = null!;
    public int DistrictId { get; set; }
    public District District { get; set; } = null!;
    public DateTime DateOfStartWork { get; set; }
    public DateTime? DateOfEndWork { get; set; }
}