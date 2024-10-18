namespace lab3.Queries.GetPatientsByDoctorId;

public class GetPatientsByDoctorIdQueryResponse
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime VisitDate { get; set; }
    public DateTime? SickLeaveDuration { get; set; }
}