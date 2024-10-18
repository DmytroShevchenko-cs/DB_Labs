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
            var visits = await _dbContext.Visits
                .Include(v => v.Patient)
                .ThenInclude(r => r.Human)
                .Where(v => v.Patient.PatientId == 2)
                .OrderByDescending(v => v.VisitDate)
                .Select(r => new GetVisitByPatientIdQueryResponse
                {
                    Address = r.Patient.Address,
                    VisitDate = r.VisitDate,
                    Diagnosis = r.Diagnosis
                })
                .FirstOrDefaultAsync(cancellationToken);

            return visits;

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}