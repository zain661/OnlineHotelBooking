using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HotelBooking.Application.DTOs.Hotel.Responses;
using HotelBooking.Application.DTOs.Review.Responses;
using HotelBooking.Application.Queries.HotelQueries;
using HotelBooking.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Application.Handlers.HotelHandlers
{
    public sealed class GetHotelDetailsQueryHandler : IRequestHandler<GetHotelDetailsQuery, HotelDetailsDTO>
    {
        private readonly IHotelRepo _hotelRepo;
        private readonly IReviewRepo _reviewRepo;
        private readonly IMapper _mapper;

        public GetHotelDetailsQueryHandler(IHotelRepo hotelRepo, IReviewRepo reviewRepo, IMapper mapper)
        {
            _hotelRepo = hotelRepo;
            _reviewRepo = reviewRepo;
            _mapper = mapper;
        }


        public async Task<HotelDetailsDTO> Handle(GetHotelDetailsQuery request, CancellationToken cancellationToken)
        {
            var hotel = await _hotelRepo.GetHotelByIdAsync(request.Id);

            if (hotel == null)
            {
                return null; 
            }

            var reviews = await _reviewRepo.GetReviewsByHotelId(hotel.Id)
        .ToListAsync(cancellationToken); // Fetch reviews into memory

            var averageRating = reviews
                .Select(r => r.Rating)
                .DefaultIfEmpty(0)
                .Average();

            var hotelDetailsDto = _mapper.Map<HotelDetailsDTO>(hotel);

            hotelDetailsDto.Rating = averageRating;

            hotelDetailsDto.Reviews = reviews.Select(r => new ReviewDTO
            {
                Comment = r.Comment,
                ReviewDate = r.ReviewDate,
                Rating = r.Rating
            }).ToList(); // Ensure conversion to List<ReviewDTO>

            return hotelDetailsDto;
        }
    }
}
