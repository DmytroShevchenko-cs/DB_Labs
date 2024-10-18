namespace lab3.Queries.GetPatientsByDoctorId;

using MediatR;

public class GetPatientsByDoctorIdQuery : IRequest<List<GetPatientsByDoctorIdQueryResponse>>
{
    public int DoctorId { get; set; }
}