namespace lab3.Queries.GetDoctorsInitialsByPatientId;

using Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetDoctorsInitialsByPatientIdQueryHandler : IRequestHandler<GetDoctorsInitialsByPatientIdQuery, List<GetDoctorsInitialsByPatientIdQueryResponse>>
{
    private readonly HospitalDbContext _dbContext;

    public GetDoctorsInitialsByPatientIdQueryHandler(HospitalDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<GetDoctorsInitialsByPatientIdQueryResponse>> Handle(GetDoctorsInitialsByPatientIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var visits = await _dbContext.Visits
                .Include(r => r.Schedule)
                .ThenInclude(r => r.Doctor)
                .ThenInclude(r => r.Human)
                .Where(r => r.PatientId == 2)
                .Select(r => new GetDoctorsInitialsByPatientIdQueryResponse
                {
                    DoctorInfo =string.Concat(
                        r.Schedule.Doctor.Human.LastName, ".", 
                        r.Schedule.Doctor.Human.FirstName.Substring(0, 1), ".", 
                        r.Schedule.Doctor.Human.MiddleName.Substring(0, 1), "."
                    )
                })
                .ToListAsync(cancellationToken);

            return visits;

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}