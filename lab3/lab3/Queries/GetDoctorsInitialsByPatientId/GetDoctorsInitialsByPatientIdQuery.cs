namespace lab3.Queries.GetDoctorsInitialsByPatientId;

using MediatR;

public class GetDoctorsInitialsByPatientIdQuery : IRequest<List<GetDoctorsInitialsByPatientIdQueryResponse>>
{
    public int PatientId { get; set; }
}