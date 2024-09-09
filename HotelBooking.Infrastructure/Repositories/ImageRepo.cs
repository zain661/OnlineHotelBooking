using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelBooking.Infrastructure.Repositories
{
    public class ImageRepo : IImageRepo
    {
        private readonly HotelBookingDbContext _context;

        public ImageRepo(HotelBookingDbContext context)
        {
            _context = context;
        }

        public async Task<IList<Image>> GetImagesByHotelIdAsync(Guid hotelId)
        {
            return await _context.Images
                .Where(img => img.HotelId == hotelId)
                .ToListAsync();
        }
    }
}
