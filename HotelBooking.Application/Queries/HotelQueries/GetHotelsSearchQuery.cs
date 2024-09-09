using HotelBooking.Application.DTOs.Hotel.Requests;
using HotelBooking.Application.DTOs.Hotel.Responses;
using HotelBooking.Application.Helpers;
using HotelBooking.Domain.Helpers;
using MediatR;

namespace HotelBooking.Application.Queries.HotelQueries
{
    public record GetHotelsSearchQuery(HotelSearchParameters HotelSearchParameters) : IRequest<PaginatedList<HotelSearchDTO>>;

}
