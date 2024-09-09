using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Helpers;
using HotelBooking.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace HotelBooking.Infrastructure.Repositories
{
    public class HotelRepo : IHotelRepo
    {
        private readonly HotelBookingDbContext _context;

        public HotelRepo(HotelBookingDbContext context) {
            _context = context;
        }
        public IQueryable<Hotel> GetAllHotels() // //Why Not Add await and async to IQueryable Methods:Deferred Execution: IQueryable is designed for deferred execution, meaning the query is constructed but not executed until you enumerate over it(e.g., calling ToListAsync() or FirstOrDefaultAsync()). Adding await would force execution of the query, negating the benefits of deferred execution.Flexibility: Returning IQueryable without awaiting allows the calling method to apply additional filters, joins, or sorts before the query is executed.This makes your repository methods more flexible and reusable.
        {
            var hotels = _context.Hotels
                .Include(h => h.Rooms).ThenInclude(r => r.RoomType).ThenInclude(rt => rt.Amenities)
                .Include(h => h.Images)
                .Include(h => h.City)
                .AsQueryable();
            return hotels;
        }

        public IQueryable<Hotel> GetHotelsWithActiveDiscountsQuery()
        {
            return _context.Hotels
                .AsNoTracking()
                .Include(h => h.Rooms)
                .ThenInclude(r => r.RoomType)
                .ThenInclude(rt => rt.Discounts)
                .Include(h => h.City)
                .Include(h => h.Images)
                .Where(h => h.Rooms.Any(r => r.RoomType.Discounts.Any(d => d.FromDate <= DateTime.Today && d.ToDate >= DateTime.Today)))
                .AsQueryable();
        }

        public IQueryable<Hotel> GetFilteredHotels(HotelSearchParameters searchParams)
        {
            var hotelsQuery = GetAllHotels();

            if (!string.IsNullOrWhiteSpace(searchParams.City))
            {
                hotelsQuery = hotelsQuery
                    .Where(h => h.City.Name != null && h.City.Name.ToLower() == searchParams.City);
            }

            if (searchParams.Rating.HasValue)
            {
                hotelsQuery = hotelsQuery.Where(h => h.Rating >= searchParams.Rating);
            }

            if (searchParams.MinPrice.HasValue)
            {
                hotelsQuery = hotelsQuery.Where(h => h.Rooms.Any(r => r.RoomType.PricePerNight >= searchParams.MinPrice));
            }

            if (searchParams.MaxPrice.HasValue)
            {
                hotelsQuery = hotelsQuery.Where(h => h.Rooms.Any(r => r.RoomType.PricePerNight <= searchParams.MaxPrice));
            }

            if (searchParams.Amenities != null && searchParams.Amenities.Any())
            {
                var requiredAmenities = searchParams.Amenities.ToList();

                hotelsQuery = hotelsQuery.Where(h => h.Rooms
                    .Any(r => requiredAmenities
                        .All(a => r.RoomType.Amenities
                            .Select(ra => ra.Name.ToLower())
                            .Contains(a))));
            }

            return hotelsQuery;
        }

        public async Task<Hotel> CreateHotelAsync(Hotel hotel)
        {
            await _context.Hotels.AddAsync(hotel);
            await _context.SaveChangesAsync();
            return hotel;  
        }
        public async Task<Hotel> DeleteHotelByIdAsync(Guid id)
        {
            // Retrieve the hotel entity from the database
            var hotel = await _context.Hotels.FindAsync(id);

            // Check if the hotel exists
            if (hotel == null)
            {
                // Handle the case where the hotel was not found (e.g., throw an exception or return null)
                throw new KeyNotFoundException($"Hotel with ID {id} not found.");
            }

            // Remove the hotel entity from the context
            _context.Hotels.Remove(hotel);

            // Save changes to the database
            await _context.SaveChangesAsync();

            // Return the deleted hotel object
            return hotel;
        }


        public async Task<Hotel> GetHotelByIdAsync(Guid id)
        {
            // Retrieve the hotel entity from the database
            var hotel = await _context.Hotels.FindAsync(id);

            // Check if the hotel exists and return it
            if (hotel == null)
            {
                // Handle the case where the hotel was not found
                // For example, throw an exception or return null based on your needs
                throw new KeyNotFoundException($"Hotel with ID {id} not found.");
            }

            return hotel;
        }


        public async Task<Hotel> GetHotelByNameAsync(string name)
        {
            // Retrieve the hotel entity from the database by its name
            var hotel = await _context.Hotels
                .FirstOrDefaultAsync(h => h.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            // Return the hotel object (or null if not found)
            return hotel;
        }

        public async Task<Hotel> UpdateHotelAsync(Hotel hotel)
        {
            _context.Hotels.Update(hotel); //Detailed Points: _context.Hotels.Update(hotel);Function: Marks the hotel entity as modified in the context.Why No await: This method performs an in-memory operation, which is instantaneous and does not require waiting for external resources. It updates the state of the entity in the DbContext await _context.SaveChangesAsync(); Function: Persists all changes made in the DbContext to the database asynchronously.Why await: This method performs an I / O - bound operation(sending changes to the database), so it needs to be awaited to ensure it completes before continuing with the method.
            await _context.SaveChangesAsync();
            return hotel;

        }
    }
}
