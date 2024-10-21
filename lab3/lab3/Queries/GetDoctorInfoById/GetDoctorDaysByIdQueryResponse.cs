namespace lab3.Queries.GetDoctorInfoById;

using Database.Enum;

public class GetDoctorDaysByIdQueryResponse
{
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public Weekday Day { get; set; }
    public int RoomNumber { get; set; }
}