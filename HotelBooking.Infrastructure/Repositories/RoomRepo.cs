using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace HotelBooking.Infrastructure.Repositories
{
    public class RoomRepo : IRoomRepo
    {
        private readonly HotelBookingDbContext _context;

        public RoomRepo(HotelBookingDbContext context)
        {
            _context = context;
        }

        public IQueryable<Room> GetAvailableRooms(int? numberOfAdults, int? numberOfChildren, DateTime? checkIn, DateTime? checkOut)
        {
            return _context.Rooms
                .Where(r => r.AdultsCapacity == numberOfAdults &&
                            r.ChildrenCapacity == numberOfChildren &&
                            !_context.Bookings
                                .Where(b => b.Rooms.Contains(r))
                                .Any(b => b.CheckInDate < checkOut && b.CheckOutDate > checkIn));
        }
        public IQueryable<Room> GetAvailableRoomsByHotel(Guid? hotelId, int? numberOfAdults, int? numberOfChildren, DateTime? checkIn, DateTime? checkOut)
        {
            return _context.Rooms
                .Where(r => r.HotelId == hotelId &&
                            r.AdultsCapacity == numberOfAdults &&
                            r.ChildrenCapacity == numberOfChildren &&
                            !_context.Bookings
                                .Where(b => b.Rooms.Contains(r))
                                .Any(b => b.CheckInDate < checkOut && b.CheckOutDate > checkIn));
        }

        public IQueryable<Room> FilterRoomsByPrice(IQueryable<Room> rooms, float? minPrice, float? maxPrice)
        {
            if (minPrice.HasValue)
            {
                rooms = rooms.Where(r => r.RoomType.PricePerNight >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                rooms = rooms.Where(r => r.RoomType.PricePerNight <= maxPrice.Value);
            }

            return rooms;
        }

        public IQueryable<Room> FilterRoomsByAmenities(IQueryable<Room> rooms, IList<string> amenities)
        {
            // Include RoomType and its related Amenities in the query
            rooms = rooms.Include(r => r.RoomType)
                         .ThenInclude(rt => rt.Amenities);

            if (amenities != null && amenities.Any())
            {
                rooms = rooms.Where(r => amenities.All(a => r.RoomType.Amenities.Any(am => am.Name.ToLower() == a.ToLower())));
            }

            return rooms;
        }
        public float CalculatePricePerNight(Room room, IEnumerable<string> selectedAmenities)
        {
            // Ensure room and room.RoomType are not null
            if (room == null)
            {
                throw new ArgumentNullException(nameof(room), "Room cannot be null");
            }

            if (room.RoomType == null)
            {
                throw new ArgumentNullException(nameof(room.RoomType), "RoomType cannot be null");
            }

            // Get the list of amenities from the RoomType
            var amenitiesList = room.RoomType.Amenities ?? Enumerable.Empty<Amenity>();

            // Calculate the additional price for the selected amenities
            var additionalPrice = amenitiesList
                .Where(a => selectedAmenities.Contains(a.Name.ToLower()))
                .Sum(a => a.Price);

            // Return the base price plus any additional amenity prices
            return room.RoomType.PricePerNight + additionalPrice;
        }
        public async Task<bool> IsRoomAvailableAsync(Guid roomId, DateTime checkInDate, DateTime checkOutDate)
        {
            var room = await _context.Rooms
                .Include(r => r.Bookings)
                .FirstOrDefaultAsync(r => r.Id == roomId);

            if (room == null)
            {
                throw new KeyNotFoundException("Room not found");
            }

            // التحقق من وجود أي حجز يتداخل مع التواريخ المحددة
            var isAvailable = !room.Bookings.Any(b =>
                (checkInDate < b.CheckOutDate && checkOutDate > b.CheckInDate));

            return isAvailable;
        }

        // طريقة للتحقق من وجود الغرف في الداتا بيس وتوفرها
        public async Task<List<Room>> GetAvailableRoomsByIdsAsync(List<Guid> roomIds, DateTime checkInDate, DateTime checkOutDate)
        {
            var rooms = await _context.Rooms
                .Include(r => r.RoomType)
                .Include(r => r.Hotel).ThenInclude(h => h.City)
                .Where(r => roomIds.Contains(r.Id))
                .ToListAsync();

            // تحقق من توفر كل غرفة باستخدام الطريقة الفردية
            var availableRooms = new List<Room>();

            foreach (var room in rooms)
            {
                if (await IsRoomAvailableAsync(room.Id, checkInDate, checkOutDate))
                {
                    availableRooms.Add(room);
                }
            }

            return availableRooms;
        }

        public async Task<Room> GetRoomByIdAsync(Guid id)
        {
            return await _context.Rooms.FindAsync(id);
        }
        public async Task<List<Room>> GetAllRoomsAsync()
        {
            return await _context.Rooms.ToListAsync();
        }
        public async Task<Room> AddRoomAsync(Room room)
        {
            room.Id = Guid.NewGuid();  // Ensure Id is set
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
            return room;
        }

        public async Task<Room> UpdateRoomAsync(Room room)
        {
            _context.Entry(room).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return room;
        }

        public async Task<bool> DeleteRoomAsync(Guid id)
        {
            var room = await _context.Rooms.FindAsync(id);
            if (room == null) return false;

            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
            return true;
        }



    }
}
