using MediatR;
using HotelBooking.Application.DTOs.Hotel.Responses;

namespace HotelBooking.Application.Queries.HotelQueries
{
    public record GetFeaturedDealsQuery(int Count) : IRequest<List<FeaturedDealDTO>>;
}
