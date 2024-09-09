using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Interfaces;

namespace HotelBooking.Infrastructure.Repositories
{
    public class ReviewRepo : IReviewRepo
    {
        private readonly HotelBookingDbContext _context;

        public ReviewRepo(HotelBookingDbContext context) {
            _context = context;
        }
        public IQueryable<Review> GetReviewsByHotelId(Guid hotelId)
        {
            return _context.Reviews.Where(r => r.Booking.Rooms.Any(room => room.HotelId == hotelId)).AsQueryable();
        }
    }
}
