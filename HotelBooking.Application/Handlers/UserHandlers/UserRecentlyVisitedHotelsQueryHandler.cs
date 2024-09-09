using Microsoft.EntityFrameworkCore;
using AutoMapper;
using HotelBooking.Application.DTOs.Hotel.Responses;
using HotelBooking.Application.Queries.UserQueries;
using HotelBooking.Domain.Interfaces;
using MediatR;

namespace HotelBooking.Application.Handlers.UserHandlers
{
    public sealed class UserRecentlyVisitedHotelsQueryHandler : IRequestHandler<GetUser_sRecentlyVisitedHotelsQuery, List<VisitedHotelsDTO>>
    {
        private readonly IBookingRepo _bookingRepo;
        private readonly IUserRepo _userRepo;
        private readonly IMapper _mapper;

        public UserRecentlyVisitedHotelsQueryHandler(IBookingRepo bookingRepo, IUserRepo userRepo, IMapper mapper) {
            _bookingRepo = bookingRepo;
            _userRepo = userRepo;
            _mapper = mapper;
        }
        public async Task<List<VisitedHotelsDTO>> Handle(GetUser_sRecentlyVisitedHotelsQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepo.GetUserByEmailAsync(request.Email); //Without await: You’re working with a Task<User>, not a User, which causes a type mismatch when you try to access properties.

            var bookings = await _bookingRepo.GetLastUserBookingsAsync(user.Id).OrderByDescending(b=> b.BookingDate)
                .Take(request.Count).ToListAsync();

            var HotelDTO = _mapper.Map<List<VisitedHotelsDTO>>(bookings);

            return HotelDTO;

        }
    }
}
