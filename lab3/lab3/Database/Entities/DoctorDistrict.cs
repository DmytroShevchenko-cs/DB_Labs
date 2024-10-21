namespace lab3.Database.Entities;

public class DoctorDistrict
{
    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; } = null!;
    public int DistrictId { get; set; }
    public District District { get; set; } = null!;
    public DateTime DateOfStartWork { get; set; }
    public DateTime? DateOfEndWork { get; set; }
}