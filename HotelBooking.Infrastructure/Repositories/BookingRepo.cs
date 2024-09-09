using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Infrastructure.Repositories
{
    public class BookingRepo : IBookingRepo
    {
        private readonly HotelBookingDbContext _context;

        public BookingRepo(HotelBookingDbContext context) { 
            _context = context;
        }
        public IQueryable<Booking> GetLastUserBookingsAsync(Guid userId)
        {
            return _context.Bookings.Where(b =>b.UserId == userId)
                .Include(b => b.Rooms)
        .ThenInclude(r => r.RoomType)
    .Include(b => b.Rooms)
        .ThenInclude(r => r.Hotel)
            .ThenInclude(h => h.City)
    .Include(b => b.Rooms)
        .ThenInclude(r => r.Hotel)
            .ThenInclude(h => h.Images).AsQueryable();
                
        }

        public async Task AddAsync(Booking booking)
        {
            // إضافة الحجز إلى مجموعة الحجوزات
            await _context.Bookings.AddAsync(booking);

            // حفظ التغييرات في قاعدة البيانات
            await _context.SaveChangesAsync();
        }
    }
}
