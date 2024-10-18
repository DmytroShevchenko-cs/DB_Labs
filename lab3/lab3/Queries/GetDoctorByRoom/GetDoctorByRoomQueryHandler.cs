namespace lab3.Queries.GetDoctorByRoom;

using Database;
using GetDoctorInfoById;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetDoctorByRoomQueryHandler: IRequestHandler<GetDoctorByRoomQuery, List<GetDoctorByRoomQueryResponse>>
{
    private readonly HospitalDbContext _dbContext;

    public GetDoctorByRoomQueryHandler(HospitalDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<GetDoctorByRoomQueryResponse>> Handle(GetDoctorByRoomQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var doctorDays = await _dbContext.Schedules
                .Include(sc => sc.Doctor)
                .ThenInclude(d => d.Human)
                .Where(sc => sc.RoomNumber == 102) 
                .Select(sc => new GetDoctorByRoomQueryResponse
                {
                    FirstName = sc.Doctor.Human.FirstName,
                    LastName = sc.Doctor.Human.LastName,
                    MiddleName = sc.Doctor.Human.MiddleName
                })
                .Distinct() 
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