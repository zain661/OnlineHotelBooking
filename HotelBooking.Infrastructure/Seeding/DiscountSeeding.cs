using HotelBooking.Domain.Entities;

namespace Infrastructure.Seeding;

public static class DiscountSeeding
{
    public static IEnumerable<Discount> SeedData()
    {
        return new List<Discount>
        {
            new()
            {
                Id = new Guid("a1aebf1a-5c85-4e54-81a7-2b59c3d1d3b8"),
                RoomTypeId = new Guid("5a5de3b8-3ed8-4f0a-bda9-cf73225a64a1"), // Suite
                DiscountPercentage = 10.0f,
                FromDate = DateTime.Today.AddDays(-10),
                ToDate = DateTime.Today.AddDays(10)
            },
            new()
            {
                Id = new Guid("b3f70a88-53e5-4b35-9d08-59632cfaf872"),
                RoomTypeId = new Guid("d67ddbe4-1f1a-4d85-bcc1-ec3a475ecb68"), // Deluxe
                DiscountPercentage = 15.0f,
                FromDate = DateTime.Today.AddDays(-5),
                ToDate = DateTime.Today.AddDays(5)
            },
            new()
            {
                Id = new Guid("c6d14b29-1d59-42ab-b13f-15d5939e4ae4"),
                RoomTypeId = new Guid("4b4c0ea5-0b9a-4a20-8ad9-77441fb912d2"), // Standard
                DiscountPercentage = 20.0f,
                FromDate = DateTime.Today.AddDays(-2),
                ToDate = DateTime.Today.AddDays(7)
            }
        };
    }
}
