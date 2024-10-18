namespace lab3.Queries.GetNumbersOfPatients;

public class GetNumbersOfPatientsQueryResponse
{
    public string PolyclinicName { get; set; } = null!;
    public string DoctorName { get; set; } = null!;
    public int PatientCount  { get; set; }
}