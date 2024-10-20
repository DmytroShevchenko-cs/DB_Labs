namespace lab3.Queries.GetDoctorInfoById;

using MediatR;

public class GetDoctorDaysByIdQuery : IRequest<List<GetDoctorDaysByIdQueryResponse>>
{
    public int DoctorId { get; set; }
}