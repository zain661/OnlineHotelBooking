using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBooking.Application.DTOs.City;
using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Infrastructure.Repositories
{
    public class CityRepo : ICityRepo
    {
        private readonly HotelBookingDbContext _context;

        public CityRepo(HotelBookingDbContext context) { 
            _context = context;
        }
        public IQueryable<City> GetVisitedCitiesQuery()
        {
            return _context.Bookings
                .Include(b => b.Rooms)
                    .ThenInclude(r => r.Hotel)
                        .ThenInclude(h => h.City)
                .SelectMany(b => b.Rooms.Select(r => r.Hotel.City));
        }

        public async Task<IEnumerable<City>> GetAllCitiesAsync()
        {
            return await _context.Cities
        .Include(c => c.Hotels)  // Ensure Hotels are included
        .ToListAsync();
        }

        public async Task<City> GetCityByIdAsync(Guid id)
        {
            return await _context.Cities.FindAsync(id);
        }

        public async Task<City> AddCityAsync(City city)
        {
            _context.Cities.Add(city);
            await _context.SaveChangesAsync();
            return city;
        }

        public async Task<City> UpdateCityAsync(City city)
        {
            _context.Cities.Update(city);
            await _context.SaveChangesAsync();
            return city;
        }

        public async Task<bool> DeleteCityAsync(Guid id)
        {
            var city = await _context.Cities.FindAsync(id);
            if (city == null) return false;

            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();
            return true;
        }



    }
}
