namespace lab3.Queries.GetVisitCountWithinMonthByPatientId;

using MediatR;

public class GetVisitCountWithinMonthByPatientIdQuery : IRequest<int>
{
    public int PatientId { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }
}