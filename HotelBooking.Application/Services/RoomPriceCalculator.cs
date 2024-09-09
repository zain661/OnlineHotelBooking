using HotelBooking.Application.Abstractions;
using HotelBooking.Domain.Entities;

public class RoomPriceCalculator : IRoomPriceCalculator
{
    public float CalculatePricePerNight(Room room, IEnumerable<string> amenities)
    {
        // Ensure room and room.RoomType are not null
        if (room == null)
        {
            throw new ArgumentNullException(nameof(room), "Room cannot be null");
        }

        // Ensure room.RoomType.Amenities is not null
        var amenitiesList = room.RoomType.Amenities ?? Enumerable.Empty<Amenity>();

        var additionalPrice = amenitiesList
            .Where(a => amenities.Contains(a.Name.ToLower()))
            .Sum(a => a.Price);
        
        // If additionalPrice is zero, just return the base price
        return room.RoomType.PricePerNight + additionalPrice;
    }
}
