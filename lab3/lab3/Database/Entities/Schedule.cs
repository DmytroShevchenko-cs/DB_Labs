namespace lab3.Database.Entities;

using Enum;

public class Schedule
{
    public int ScheduleId { get; set; }
    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; } = null!;
    public int DistrictId { get; set; }
    public District District { get; set; } = null!;
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public Weekday Day { get; set; }
    public int RoomNumber { get; set; }
    
    public ICollection<Visit> Visits { get; set; } = null!;
}