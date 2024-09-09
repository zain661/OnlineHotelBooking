using HotelBooking.Domain.Entities;


namespace HotelBooking.Domain.Interfaces
{
    public interface IRoomRepo
    {
        IQueryable<Room> GetAvailableRooms(int? numberOfAdults, int? numberOfChildren, DateTime? checkIn, DateTime? checkOut);
        IQueryable<Room> GetAvailableRoomsByHotel(Guid? hotelId, int? numberOfAdults, int? numberOfChildren, DateTime? checkIn, DateTime? checkOut);
        IQueryable<Room> FilterRoomsByPrice(IQueryable<Room> rooms, float? minPrice, float? maxPrice);
        IQueryable<Room> FilterRoomsByAmenities(IQueryable<Room> rooms, IList<string> amenities);
        float CalculatePricePerNight(Room room, IEnumerable<string> selectedAmenities);
        Task<bool> IsRoomAvailableAsync(Guid roomId, DateTime checkInDate, DateTime checkOutDate);
        Task<List<Room>> GetAvailableRoomsByIdsAsync(List<Guid> roomIds, DateTime checkInDate, DateTime checkOutDate);
        Task<Room> GetRoomByIdAsync(Guid id);
        Task<Room> AddRoomAsync(Room room);
        Task<Room> UpdateRoomAsync(Room room);
        Task<bool> DeleteRoomAsync(Guid id);
        Task<List<Room>> GetAllRoomsAsync();
    }
}
