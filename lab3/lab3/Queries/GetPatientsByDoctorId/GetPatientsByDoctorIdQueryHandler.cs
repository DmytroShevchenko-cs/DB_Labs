namespace lab3.Queries.GetPatientsByDoctorId;

using Database;
using GetDoctorsInitialsByPatientId;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetPatientsByDoctorIdQueryHandler : IRequestHandler<GetPatientsByDoctorIdQuery, List<GetPatientsByDoctorIdQueryResponse>>
{
    private readonly HospitalDbContext _dbContext;

    public GetPatientsByDoctorIdQueryHandler(HospitalDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<GetPatientsByDoctorIdQueryResponse>> Handle(GetPatientsByDoctorIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var patients = await _dbContext.Visits
                .Include(r => r.Patient)
                .ThenInclude(r => r.Human)
                .Include(r => r.Schedule)
                .Where(r => r.Schedule.DoctorId == request.DoctorId)
                .Where(r => r.SickLeaveDuration > DateTime.Now)
                .Select(r => new GetPatientsByDoctorIdQueryResponse
                {
                    FirstName = r.Patient.Human.FirstName,
                    LastName = r.Patient.Human.LastName,
                    VisitDate = r.VisitDate,
                    SickLeaveDuration = r.SickLeaveDuration
                })
                .ToListAsync(cancellationToken);

            return patients;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}