namespace lab3.Queries.GetNumbersOfPatients;

using Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetNumbersOfPatientsQueryHandler : IRequestHandler<GetNumbersOfPatientsQuery, List<GetNumbersOfPatientsQueryResponse>>
{
    private readonly HospitalDbContext _dbContext;

    public GetNumbersOfPatientsQueryHandler(HospitalDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<GetNumbersOfPatientsQueryResponse>> Handle(GetNumbersOfPatientsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var query = await _dbContext.Visits
                .Include(v => v.Patient)
                .Include(v => v.Schedule) 
                .ThenInclude(sc => sc.District) 
                .ThenInclude(dist => dist.Polyclinic) 
                .Include(v => v.Schedule.Doctor) 
                .ThenInclude(d => d.Human) 
                .Where(v => v.Schedule.District.Polyclinic.PolyclinicId == request.PolyclinicId)
                .GroupBy(v => new 
                {
                    PolyclinicName = v.Schedule.District.Polyclinic.Name,
                    DoctorFirstName = v.Schedule.Doctor.Human.FirstName,
                    DoctorMiddleName = v.Schedule.Doctor.Human.MiddleName,
                    DoctorLastName = v.Schedule.Doctor.Human.LastName
                })
                .Select(g => new GetNumbersOfPatientsQueryResponse()
                {
                    PolyclinicName = g.Key.PolyclinicName,
                    DoctorName = g.Key.DoctorFirstName + " " + 
                                 (g.Key.DoctorMiddleName != null 
                                     ? g.Key.DoctorMiddleName.Substring(0, 1) + ". " 
                                     : "") + 
                                 g.Key.DoctorLastName,
                    PatientCount = g.Select(v => v.Patient.PatientId).Distinct().Count()
                })
                .OrderBy(r => r.DoctorName)
                .ToListAsync(cancellationToken);

            return query;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}