namespace lab3.Queries.GetNumbersOfPatients;

using MediatR;

public class GetNumbersOfPatientsQuery : IRequest<List<GetNumbersOfPatientsQueryResponse>>
{
    public int PolyclinicId { get; set; }
}