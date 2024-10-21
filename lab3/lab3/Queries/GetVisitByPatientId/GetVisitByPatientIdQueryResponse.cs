namespace lab3.Queries.GetVisitByPatientId;

public class GetVisitByPatientIdQueryResponse
{
    public string Address { get; set; } = null!;
    public DateTime VisitDate { get; set; }
    public string Diagnosis { get; set; } = null!;
    
}