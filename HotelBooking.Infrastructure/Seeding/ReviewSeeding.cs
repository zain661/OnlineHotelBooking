using HotelBooking.Domain.Entities;

namespace Infrastructure.Seeding;

public class ReviewSeeding
{
    public static IEnumerable<Review> SeedData()
    {
        return new List<Review>
        {
            new()
            {
                Id = new Guid("f7b8e7c9-1c9d-4f9f-9f3e-5d0e1f9d6a7f"),
                BookingId = new Guid("7d3155a2-95f8-4d9b-bc24-662ae053f1c9"),
                Rating = 4,
                Comment = "Very nice experience, highly recommended!"
            },
            new()
            {
                Id = new Guid("e6c9f7a9-0d9f-4e9d-8e4c-6d1e2f8e7c9d"),
                BookingId = new Guid("efeb3d13-3dab-46c9-aa9a-9f22dd58e06e"),
                Rating = 3,
                Comment = "Good service but could be improved."
            },
            new()
            {
                Id = new Guid("d5b9e8c9-2e9f-4d9c-8f5d-7e2e3f8f9d0e"),
                BookingId = new Guid("0bf4a177-98b8-4f67-8a56-95669c320890"),
                Rating = 5,
                Comment = "Outstanding experience! Will come back again."
            }
        };
    }
}
