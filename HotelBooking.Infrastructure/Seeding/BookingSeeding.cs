using HotelBooking.Domain.Entities;

namespace Infrastructure.Seeding
{
    public class BookingSeeding
    {
        public static IEnumerable<Booking> SeedData()
        {
            return new List<Booking>
            {
                new()
                {
                    Id = new Guid("7d3155a2-95f8-4d9b-bc24-662ae053f1c9"),
                    UserId = new Guid("af838868-a3e8-47d0-b1a3-8111396dda35"),
                    TotalAmount = 100,
                    CheckInDate = DateTime.Parse("2024-09-01"),
                    CheckOutDate = DateTime.Parse("2024-09-04"),
                    BookingDate = DateTime.Parse("2024-08-22")
                },
                new()
                {
                    Id = new Guid("efeb3d13-3dab-46c9-aa9a-9f22dd58e06e"),
                    UserId = new Guid("b748f5b2-6b48-4e5d-9e4b-c5bfa54cb1f2"),
                    TotalAmount = 150,
                    CheckInDate = DateTime.Parse("2024-09-05"),
                    CheckOutDate = DateTime.Parse("2024-09-07"),
                    BookingDate = DateTime.Parse("2024-08-28")
                },
                new()
                {
                    Id = new Guid("0bf4a177-98b8-4f67-8a56-95669c320890"),
                    UserId = new Guid("af838868-a3e8-47d0-b1a3-8111396dda35"),
                    TotalAmount = 200,
                    CheckInDate = DateTime.Parse("2024-09-12"),
                    CheckOutDate = DateTime.Parse("2024-09-18"),
                    BookingDate = DateTime.Parse("2024-09-05")
                }
            };
        }
    }
}