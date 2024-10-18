namespace lab3.Queries.GetVisitCountWithinMonthByPatientId;

using Database;
using GetVisitByPatientId;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetVisitCountWithinMonthByPatientIdQueryHandler: IRequestHandler<GetVisitCountWithinMonthByPatientIdQuery, int>
{
    private readonly HospitalDbContext _dbContext;

    public GetVisitCountWithinMonthByPatientIdQueryHandler(HospitalDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<int> Handle(GetVisitCountWithinMonthByPatientIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var visitCount = await _dbContext.Visits
                .Include(v => v.Patient)
                .ThenInclude(p => p.Human)
                .Where(v => v.PatientId == 1)
                .Where(v => v.VisitDate.Year == 2024)
                .Where(v => v.VisitDate.Month == 9)
                .CountAsync(cancellationToken);

            return visitCount;

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}