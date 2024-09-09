using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Enums;

namespace Infrastructure.Seeding;

public class HotelSeeding
{
    public static IEnumerable<Hotel> SeedData()
    {
        return new List<Hotel>
        {
            new()
            {
                Id = new Guid("e4a5d378-6a32-4b7e-917f-51c5798e6b54"),
                CityId = new Guid("c2f87e1e-3cf0-4c3e-b09b-bb2d8e5b74b9"),
                OwnerId = new Guid("4b72f22b-4a11-44d0-a62d-8a5c5cf3e7a1"),
                Name = "Cinema",
                Rating = 4,
                StreetAddress = "Mahata Street",
                Description = "Nice Hotel",
                PhoneNumber = "0599999999",
                NumberOfRooms = 100,
                Category = HotelCategory.Luxury,
            },
            new()
            {
                Id = new Guid("b8f4d9a7-73e9-4536-890e-71f1f9cfe9f2"),
                CityId = new Guid("b1f8b3e4-4e30-4c6b-8c4f-2c9c9de7d517"),
                OwnerId = new Guid("4b72f22b-4a11-44d0-a62d-8a5c5cf3e7a1"),
                Name = "Asaaf Hotel",
                Rating = 3,
                StreetAddress = "qusoor",
                Description = "Nice Hotel with differnet types of amenities",
                PhoneNumber = "0599539898",
                NumberOfRooms = 200,
                Category = HotelCategory.Boutique,
            },
            new()
            {
                Id = new Guid("9a0d6e3b-5d48-489e-a9f2-743c0fcd83b1"),
                CityId = new Guid("4a7d5f20-8b3d-4b9c-b9b6-ecb2bbd25e3c"),
                OwnerId = new Guid("9e4bfc5f-65a4-4f92-a5e6-45d7d58b90cb"),
                Name = "Gaza Hotel",
                Rating = 4,
                StreetAddress = "90 Road",
                Description = "with sea",
                PhoneNumber = "0598234183",
                NumberOfRooms = 250,
                Category = HotelCategory.Budget,
            }
        };
    }
}