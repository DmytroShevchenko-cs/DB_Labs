namespace lab3.Database.Entities;

public class DoctorDistrict
{
    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; }
    public int DistrictId { get; set; }
    public District District { get; set; }
    public DateTime DateOfStartWork { get; set; }
    public DateTime? DateOfEndWork { get; set; }
}