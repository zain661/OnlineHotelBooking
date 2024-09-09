using System;
using System.Collections.Generic;

namespace Infrastructure.Seeding
{
    public class AmenityRoomTypeSeeding
    {
        public static IEnumerable<object> SeedData()
        {
            return new List<object>
            {
                // Seeding relationships between Amenities and RoomTypes
                new { AmenitiesId = 1, RoomTypesRoomTypeId = new Guid("5a5de3b8-3ed8-4f0a-bda9-cf73225a64a1") }, // Free Wi-Fi for Suite
                new { AmenitiesId = 1, RoomTypesRoomTypeId = new Guid("d67ddbe4-1f1a-4d85-bcc1-ec3a475ecb68") }, // Free Wi-Fi for Deluxe
                new { AmenitiesId = 1, RoomTypesRoomTypeId = new Guid("4b4c0ea5-0b9a-4a20-8ad9-77441fb912d2") }, // Free Wi-Fi for Standard

                new { AmenitiesId = 2, RoomTypesRoomTypeId = new Guid("5a5de3b8-3ed8-4f0a-bda9-cf73225a64a1") }, // Swimming Pool for Suite
                new { AmenitiesId = 2, RoomTypesRoomTypeId= new Guid("d67ddbe4-1f1a-4d85-bcc1-ec3a475ecb68") }, // Swimming Pool for Deluxe

                new { AmenitiesId = 3, RoomTypesRoomTypeId = new Guid("5a5de3b8-3ed8-4f0a-bda9-cf73225a64a1") }, // Gym for Suite
                new { AmenitiesId = 3, RoomTypesRoomTypeId = new Guid("d67ddbe4-1f1a-4d85-bcc1-ec3a475ecb68") }  // Gym for Deluxe
            };
        }
    }
}
