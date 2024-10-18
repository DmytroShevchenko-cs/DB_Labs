namespace lab3.Queries.GetVisitByPatientId;

using MediatR;

public class GetVisitByPatientIdQuery : IRequest<GetVisitByPatientIdQueryResponse>
{
    public int PatientId { get; set; }
}