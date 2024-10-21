namespace lab3.Queries.GetDoctorInfoById;

using Database;
using Database.Enum;
using GetDoctorsInitialsByPatientId;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetDoctorDaysByIdQueryHandler : IRequestHandler<GetDoctorDaysByIdQuery, List<GetDoctorDaysByIdQueryResponse>>
{
    private readonly HospitalDbContext _dbContext;

    public GetDoctorDaysByIdQueryHandler(HospitalDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<GetDoctorDaysByIdQueryResponse>> Handle(GetDoctorDaysByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var doctorDays = await _dbContext.Schedules
                .Include(r => r.Doctor)
                .Where(r => r.DoctorId == request.DoctorId)
                .Select(r => new GetDoctorDaysByIdQueryResponse
                {
                    StartTime = r.StartTime,
                    EndTime = r.EndTime,
                    Day = r.Day,
                    RoomNumber = r.RoomNumber
                })
                .OrderBy(r => r.Day)
                .ToListAsync(cancellationToken);

            return doctorDays;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}