namespace lab3.Queries.GetDoctorByRoom;

using MediatR;

public class GetDoctorByRoomQuery : IRequest<List<GetDoctorByRoomQueryResponse>>
{
    public int RoomNumber { get; set; }
}