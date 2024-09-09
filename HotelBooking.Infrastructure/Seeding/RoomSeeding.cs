using HotelBooking.Domain.Entities;

namespace Infrastructure.Seeding
{
    public class RoomSeeding
    {
        public static IEnumerable<Room> SeedData()
        {
            return new List<Room>
            {
                new()
                {
                    Id = new Guid("a98b8a9d-4c5a-4a90-a2d2-5f1441b93db6"),
                    RoomTypeId = new Guid("5a5de3b8-3ed8-4f0a-bda9-cf73225a64a1"),
                    HotelId = new Guid("e4a5d378-6a32-4b7e-917f-51c5798e6b54"),
                    AdultsCapacity = 2,
                    ChildrenCapacity = 1,
                    Rating = 4.5f
                },
                new()
                {
                    Id = new Guid("4e1cb3d9-bc3b-4997-a3d5-0c56cf17fe7a"),
                    RoomTypeId = new Guid("d67ddbe4-1f1a-4d85-bcc1-ec3a475ecb68"),
                    HotelId = new Guid("b8f4d9a7-73e9-4536-890e-71f1f9cfe9f2"),
                    AdultsCapacity = 3,
                    ChildrenCapacity = 2,
                    Rating = 4.2f
                },
                new()
                {
                    Id = new Guid("c6898b7e-ee09-4b36-8b20-22e8c2a63e29"),
                    RoomTypeId = new Guid("4b4c0ea5-0b9a-4a20-8ad9-77441fb912d2"),
                    HotelId = new Guid("b8f4d9a7-73e9-4536-890e-71f1f9cfe9f2"),
                    AdultsCapacity = 4,
                    ChildrenCapacity = 1,
                    Rating = 4.8f
                }
            };
        }
    }
}