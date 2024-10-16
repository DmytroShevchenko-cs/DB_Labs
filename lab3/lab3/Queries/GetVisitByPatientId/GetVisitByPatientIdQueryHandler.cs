namespace lab3.Queries.GetVisitByPatientId;

using Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetVisitByPatientIdQueryHandler : IRequestHandler<GetVisitByPatientIdQuery, GetVisitByPatientIdQueryResponse>
{
    private readonly HospitalDbContext _dbContext;

    public GetVisitByPatientIdQueryHandler(HospitalDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<GetVisitByPatientIdQueryResponse> Handle(GetVisitByPatientIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var visits = await _dbContext.Visits.ToListAsync(cancellationToken);
            return new GetVisitByPatientIdQueryResponse()
            {
                ids = visits.Select(r => r.VisitId).ToList()
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}