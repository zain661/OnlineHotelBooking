using HotelBooking.Domain.Entities;


namespace Infrastructure.Seeding
{
    public class AmenitySeeding
    {
        public static IEnumerable<Amenity> SeedData()
        {
            return new List<Amenity>
            {
                new Amenity
                {
                    Id = 1,
                    Name = "Free Wi-Fi",
                    Description = "High-speed internet access",
                    Price = 0
                },
                new Amenity
                {
                    Id = 2,
                    Name = "Swimming Pool",
                    Description = "Outdoor swimming pool",
                    Price = 50
                },
                new Amenity
                {
                    Id = 3,
                    Name = "Gym",
                    Description = "Fully equipped fitness center",
                    Price = 30
                }
            };
        }
    }
}
