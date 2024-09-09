using HotelBooking.Application.DTOs.Room.Requests;
using HotelBooking.Application.DTOs.Room.Responses;
using HotelBooking.Application.Helpers;
using MediatR;

namespace HotelBooking.Application.Queries.RoomQueries
{
    public record GetAvailableRoomsQuery(Guid HotelId, RoomSearchParameters roomSearchParameters): IRequest<PaginatedList<AvailableRoomsDTO>>;
}
