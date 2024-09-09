using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Enums;

namespace InfrastructureSeeding;

public class RoomTypeSeeding
{
    public static IEnumerable<RoomType> SeedData()
    {
        return new List<RoomType>
        {
            new()
            {
                RoomTypeId = new Guid("5a5de3b8-3ed8-4f0a-bda9-cf73225a64a1"),
                Category = RoomCategory.Suite,
                PricePerNight = 100.0f
            },
            new()
            {
                RoomTypeId = new Guid("d67ddbe4-1f1a-4d85-bcc1-ec3a475ecb68"),
                Category = RoomCategory.Deluxe,
                PricePerNight = 150.0f
            },
            new()
            {
                RoomTypeId = new Guid("4b4c0ea5-0b9a-4a20-8ad9-77441fb912d2"),
                Category = RoomCategory.Standard,
                PricePerNight = 200.0f
            }
        };
    }
}