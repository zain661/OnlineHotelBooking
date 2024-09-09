using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelBooking.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedingTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Amenities",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "High-speed internet access", "Free Wi-Fi", 0 },
                    { 2, "Outdoor swimming pool", "Swimming Pool", 50 },
                    { 3, "Fully equipped fitness center", "Gym", 30 }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryName", "Name", "PostOffice" },
                values: new object[,]
                {
                    { new Guid("4a7d5f20-8b3d-4b9c-b9b6-ecb2bbd25e3c"), "Gaza", "Gaza", "GGG" },
                    { new Guid("b1f8b3e4-4e30-4c6b-8c4f-2c9c9de7d517"), "Jordan", "Amman", "AAA" },
                    { new Guid("c2f87e1e-3cf0-4c3e-b09b-bb2d8e5b74b9"), "Palestine", "Jenin", "JJJ" }
                });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("4b72f22b-4a11-44d0-a62d-8a5c5cf3e7a1"), "zaid2001@gmail.com", "Zaid", "Ali", "0569451796" },
                    { new Guid("9e4bfc5f-65a4-4f92-a5e6-45d7d58b90cb"), "rawan2000@gmail.com", "Rawan", "Ibraheem", "05999359292" }
                });

            migrationBuilder.InsertData(
                table: "RoomTypes",
                columns: new[] { "RoomTypeId", "Category", "PricePerNight" },
                values: new object[,]
                {
                    { new Guid("4b4c0ea5-0b9a-4a20-8ad9-77441fb912d2"), "Standard", 200.0 },
                    { new Guid("5a5de3b8-3ed8-4f0a-bda9-cf73225a64a1"), "Suite", 100.0 },
                    { new Guid("d67ddbe4-1f1a-4d85-bcc1-ec3a475ecb68"), "Deluxe", 150.0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password", "PhoneNumber", "RefreshToken", "RefreshTokenExpiryTime", "Role" },
                values: new object[,]
                {
                    { new Guid("af838868-a3e8-47d0-b1a3-8111396dda35"), "zaynassaf2001@gmail.com", "Zain", "Assaf", "hashedpassword1", "123-456-7890", null, null, "Admin" },
                    { new Guid("b748f5b2-6b48-4e5d-9e4b-c5bfa54cb1f2"), "leenhammad@example.com", "Leen", "Hammad", "hashedpassword2", "987-654-3210", null, null, "RegularUser" }
                });

            migrationBuilder.InsertData(
                table: "AmenityRoomType",
                columns: new[] { "AmenitiesId", "RoomTypesRoomTypeId" },
                values: new object[,]
                {
                    { 1, new Guid("4b4c0ea5-0b9a-4a20-8ad9-77441fb912d2") },
                    { 1, new Guid("5a5de3b8-3ed8-4f0a-bda9-cf73225a64a1") },
                    { 1, new Guid("d67ddbe4-1f1a-4d85-bcc1-ec3a475ecb68") },
                    { 2, new Guid("5a5de3b8-3ed8-4f0a-bda9-cf73225a64a1") },
                    { 2, new Guid("d67ddbe4-1f1a-4d85-bcc1-ec3a475ecb68") },
                    { 3, new Guid("5a5de3b8-3ed8-4f0a-bda9-cf73225a64a1") },
                    { 3, new Guid("d67ddbe4-1f1a-4d85-bcc1-ec3a475ecb68") }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "BookingDate", "CheckInDate", "CheckOutDate", "TotalAmount", "UserId" },
                values: new object[,]
                {
                    { new Guid("0bf4a177-98b8-4f67-8a56-95669c320890"), new DateTime(2024, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 200.0, new Guid("af838868-a3e8-47d0-b1a3-8111396dda35") },
                    { new Guid("7d3155a2-95f8-4d9b-bc24-662ae053f1c9"), new DateTime(2024, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 100.0, new Guid("af838868-a3e8-47d0-b1a3-8111396dda35") },
                    { new Guid("efeb3d13-3dab-46c9-aa9a-9f22dd58e06e"), new DateTime(2024, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 150.0, new Guid("b748f5b2-6b48-4e5d-9e4b-c5bfa54cb1f2") }
                });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "DiscountPercentage", "FromDate", "RoomTypeId", "ToDate" },
                values: new object[,]
                {
                    { new Guid("a1aebf1a-5c85-4e54-81a7-2b59c3d1d3b8"), 10f, new DateTime(2024, 8, 17, 0, 0, 0, 0, DateTimeKind.Local), new Guid("5a5de3b8-3ed8-4f0a-bda9-cf73225a64a1"), new DateTime(2024, 9, 6, 0, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("b3f70a88-53e5-4b35-9d08-59632cfaf872"), 15f, new DateTime(2024, 8, 22, 0, 0, 0, 0, DateTimeKind.Local), new Guid("d67ddbe4-1f1a-4d85-bcc1-ec3a475ecb68"), new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Local) },
                    { new Guid("c6d14b29-1d59-42ab-b13f-15d5939e4ae4"), 20f, new DateTime(2024, 8, 25, 0, 0, 0, 0, DateTimeKind.Local), new Guid("4b4c0ea5-0b9a-4a20-8ad9-77441fb912d2"), new DateTime(2024, 9, 3, 0, 0, 0, 0, DateTimeKind.Local) }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Category", "CityId", "Description", "Name", "NumberOfRooms", "OwnerId", "PhoneNumber", "Rating", "StreetAddress" },
                values: new object[,]
                {
                    { new Guid("9a0d6e3b-5d48-489e-a9f2-743c0fcd83b1"), "Budget", new Guid("4a7d5f20-8b3d-4b9c-b9b6-ecb2bbd25e3c"), "with sea", "Gaza Hotel", 250, new Guid("9e4bfc5f-65a4-4f92-a5e6-45d7d58b90cb"), "0598234183", 4.2f, "90 Road" },
                    { new Guid("b8f4d9a7-73e9-4536-890e-71f1f9cfe9f2"), "Boutique", new Guid("b1f8b3e4-4e30-4c6b-8c4f-2c9c9de7d517"), "Nice Hotel with differnet types of amenities", "Asaaf Hotel", 200, new Guid("4b72f22b-4a11-44d0-a62d-8a5c5cf3e7a1"), "0599539898", 3.8f, "qusoor" },
                    { new Guid("e4a5d378-6a32-4b7e-917f-51c5798e6b54"), "Luxury", new Guid("c2f87e1e-3cf0-4c3e-b09b-bb2d8e5b74b9"), "Nice Hotel", "Cinema", 100, new Guid("4b72f22b-4a11-44d0-a62d-8a5c5cf3e7a1"), "0599999999", 4.5f, "Mahata Street" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CityId", "Format", "HotelId", "OwnerType", "Type", "Url" },
                values: new object[,]
                {
                    { new Guid("513e98e7-ed70-42ac-a3de-8da2eeacc809"), new Guid("4a7d5f20-8b3d-4b9c-b9b6-ecb2bbd25e3c"), "Png", null, "City", "Gallery", "https://example.com/image5.png" },
                    { new Guid("540ea76c-4773-46e7-a847-924ddf3a6036"), new Guid("c2f87e1e-3cf0-4c3e-b09b-bb2d8e5b74b9"), "Png", null, "City", "Thumbnail", "https://example.com/image2.png" },
                    { new Guid("78d5b776-b6ac-4cb6-843b-2a1b8ffda097"), new Guid("b1f8b3e4-4e30-4c6b-8c4f-2c9c9de7d517"), "Png", null, "City", "Thumbnail", "https://example.com/image4.png" },
                    { new Guid("3b5769cd-ce5c-449c-917a-9bd218749021"), null, "Jpg", new Guid("e4a5d378-6a32-4b7e-917f-51c5798e6b54"), "Hotel", "Gallery", "https://aabhariindia.com/assets/image/9.jpg" },
                    { new Guid("6ac0f39a-edda-4ea8-941f-35679fd704ee"), null, "Jpg", new Guid("9a0d6e3b-5d48-489e-a9f2-743c0fcd83b1"), "Hotel", "Gallery", "https://watermark.lovepik.com/photo/20211123/large/lovepik-malaysia-luxury-resort-hotel-picture_500865089.jpg" },
                    { new Guid("76414f7f-1a4b-4868-b9de-0a3b59290700"), null, "Jpg", new Guid("b8f4d9a7-73e9-4536-890e-71f1f9cfe9f2"), "Hotel", "Thumbnail", "https://images.pexels.com/photos/189296/pexels-photo-189296.jpeg?cs=srgb&dl=pexels-donaldtong94-189296.jpg&fm=jpg" }
                });

            migrationBuilder.InsertData(
                table: "Payment",
                columns: new[] { "Id", "Amount", "BookingId", "Method", "Status" },
                values: new object[,]
                {
                    { new Guid("d2e6f4a9-8a7c-4b9e-8f2b-2c7c9d6a3b5e"), 100.0, new Guid("7d3155a2-95f8-4d9b-bc24-662ae053f1c9"), "CreditCard", "Completed" },
                    { new Guid("e3f7d5b9-9a8e-4b9e-9d2b-3c8d0e7c4f6e"), 150.0, new Guid("efeb3d13-3dab-46c9-aa9a-9f22dd58e06e"), "MobileWallet", "Pending" },
                    { new Guid("f4a8e6c9-0b9d-4b9f-9d3c-4c9e1f8d5a7f"), 200.0, new Guid("0bf4a177-98b8-4f67-8a56-95669c320890"), "Cash", "Cancelled" }
                });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "Id", "BookingId", "Comment", "Rating", "ReviewDate" },
                values: new object[,]
                {
                    { new Guid("d5b9e8c9-2e9f-4d9c-8f5d-7e2e3f8f9d0e"), new Guid("0bf4a177-98b8-4f67-8a56-95669c320890"), "Outstanding experience! Will come back again.", 5f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e6c9f7a9-0d9f-4e9d-8e4c-6d1e2f8e7c9d"), new Guid("efeb3d13-3dab-46c9-aa9a-9f22dd58e06e"), "Good service but could be improved.", 3f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f7b8e7c9-1c9d-4f9f-9f3e-5d0e1f9d6a7f"), new Guid("7d3155a2-95f8-4d9b-bc24-662ae053f1c9"), "Very nice experience, highly recommended!", 4f, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "AdultsCapacity", "ChildrenCapacity", "HotelId", "Rating", "RoomTypeId" },
                values: new object[,]
                {
                    { new Guid("4e1cb3d9-bc3b-4997-a3d5-0c56cf17fe7a"), 3, 2, new Guid("b8f4d9a7-73e9-4536-890e-71f1f9cfe9f2"), 4.1999998092651367, new Guid("d67ddbe4-1f1a-4d85-bcc1-ec3a475ecb68") },
                    { new Guid("a98b8a9d-4c5a-4a90-a2d2-5f1441b93db6"), 2, 1, new Guid("e4a5d378-6a32-4b7e-917f-51c5798e6b54"), 4.5, new Guid("5a5de3b8-3ed8-4f0a-bda9-cf73225a64a1") },
                    { new Guid("c6898b7e-ee09-4b36-8b20-22e8c2a63e29"), 4, 1, new Guid("b8f4d9a7-73e9-4536-890e-71f1f9cfe9f2"), 4.8000001907348633, new Guid("4b4c0ea5-0b9a-4a20-8ad9-77441fb912d2") }
                });

            migrationBuilder.InsertData(
                table: "BookingRoom",
                columns: new[] { "BookingsId", "RoomsId" },
                values: new object[,]
                {
                    { new Guid("0bf4a177-98b8-4f67-8a56-95669c320890"), new Guid("c6898b7e-ee09-4b36-8b20-22e8c2a63e29") },
                    { new Guid("7d3155a2-95f8-4d9b-bc24-662ae053f1c9"), new Guid("a98b8a9d-4c5a-4a90-a2d2-5f1441b93db6") },
                    { new Guid("efeb3d13-3dab-46c9-aa9a-9f22dd58e06e"), new Guid("4e1cb3d9-bc3b-4997-a3d5-0c56cf17fe7a") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AmenityRoomType",
                keyColumns: new[] { "AmenitiesId", "RoomTypesRoomTypeId" },
                keyValues: new object[] { 1, new Guid("4b4c0ea5-0b9a-4a20-8ad9-77441fb912d2") });

            migrationBuilder.DeleteData(
                table: "AmenityRoomType",
                keyColumns: new[] { "AmenitiesId", "RoomTypesRoomTypeId" },
                keyValues: new object[] { 1, new Guid("5a5de3b8-3ed8-4f0a-bda9-cf73225a64a1") });

            migrationBuilder.DeleteData(
                table: "AmenityRoomType",
                keyColumns: new[] { "AmenitiesId", "RoomTypesRoomTypeId" },
                keyValues: new object[] { 1, new Guid("d67ddbe4-1f1a-4d85-bcc1-ec3a475ecb68") });

            migrationBuilder.DeleteData(
                table: "AmenityRoomType",
                keyColumns: new[] { "AmenitiesId", "RoomTypesRoomTypeId" },
                keyValues: new object[] { 2, new Guid("5a5de3b8-3ed8-4f0a-bda9-cf73225a64a1") });

            migrationBuilder.DeleteData(
                table: "AmenityRoomType",
                keyColumns: new[] { "AmenitiesId", "RoomTypesRoomTypeId" },
                keyValues: new object[] { 2, new Guid("d67ddbe4-1f1a-4d85-bcc1-ec3a475ecb68") });

            migrationBuilder.DeleteData(
                table: "AmenityRoomType",
                keyColumns: new[] { "AmenitiesId", "RoomTypesRoomTypeId" },
                keyValues: new object[] { 3, new Guid("5a5de3b8-3ed8-4f0a-bda9-cf73225a64a1") });

            migrationBuilder.DeleteData(
                table: "AmenityRoomType",
                keyColumns: new[] { "AmenitiesId", "RoomTypesRoomTypeId" },
                keyValues: new object[] { 3, new Guid("d67ddbe4-1f1a-4d85-bcc1-ec3a475ecb68") });

            migrationBuilder.DeleteData(
                table: "BookingRoom",
                keyColumns: new[] { "BookingsId", "RoomsId" },
                keyValues: new object[] { new Guid("0bf4a177-98b8-4f67-8a56-95669c320890"), new Guid("c6898b7e-ee09-4b36-8b20-22e8c2a63e29") });

            migrationBuilder.DeleteData(
                table: "BookingRoom",
                keyColumns: new[] { "BookingsId", "RoomsId" },
                keyValues: new object[] { new Guid("7d3155a2-95f8-4d9b-bc24-662ae053f1c9"), new Guid("a98b8a9d-4c5a-4a90-a2d2-5f1441b93db6") });

            migrationBuilder.DeleteData(
                table: "BookingRoom",
                keyColumns: new[] { "BookingsId", "RoomsId" },
                keyValues: new object[] { new Guid("efeb3d13-3dab-46c9-aa9a-9f22dd58e06e"), new Guid("4e1cb3d9-bc3b-4997-a3d5-0c56cf17fe7a") });

            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: new Guid("a1aebf1a-5c85-4e54-81a7-2b59c3d1d3b8"));

            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: new Guid("b3f70a88-53e5-4b35-9d08-59632cfaf872"));

            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: new Guid("c6d14b29-1d59-42ab-b13f-15d5939e4ae4"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("3b5769cd-ce5c-449c-917a-9bd218749021"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("513e98e7-ed70-42ac-a3de-8da2eeacc809"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("540ea76c-4773-46e7-a847-924ddf3a6036"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("6ac0f39a-edda-4ea8-941f-35679fd704ee"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("76414f7f-1a4b-4868-b9de-0a3b59290700"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("78d5b776-b6ac-4cb6-843b-2a1b8ffda097"));

            migrationBuilder.DeleteData(
                table: "Payment",
                keyColumn: "Id",
                keyValue: new Guid("d2e6f4a9-8a7c-4b9e-8f2b-2c7c9d6a3b5e"));

            migrationBuilder.DeleteData(
                table: "Payment",
                keyColumn: "Id",
                keyValue: new Guid("e3f7d5b9-9a8e-4b9e-9d2b-3c8d0e7c4f6e"));

            migrationBuilder.DeleteData(
                table: "Payment",
                keyColumn: "Id",
                keyValue: new Guid("f4a8e6c9-0b9d-4b9f-9d3c-4c9e1f8d5a7f"));

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("d5b9e8c9-2e9f-4d9c-8f5d-7e2e3f8f9d0e"));

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("e6c9f7a9-0d9f-4e9d-8e4c-6d1e2f8e7c9d"));

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("f7b8e7c9-1c9d-4f9f-9f3e-5d0e1f9d6a7f"));

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("0bf4a177-98b8-4f67-8a56-95669c320890"));

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("7d3155a2-95f8-4d9b-bc24-662ae053f1c9"));

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("efeb3d13-3dab-46c9-aa9a-9f22dd58e06e"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("9a0d6e3b-5d48-489e-a9f2-743c0fcd83b1"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("4e1cb3d9-bc3b-4997-a3d5-0c56cf17fe7a"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("a98b8a9d-4c5a-4a90-a2d2-5f1441b93db6"));

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("c6898b7e-ee09-4b36-8b20-22e8c2a63e29"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("4a7d5f20-8b3d-4b9c-b9b6-ecb2bbd25e3c"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("b8f4d9a7-73e9-4536-890e-71f1f9cfe9f2"));

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("e4a5d378-6a32-4b7e-917f-51c5798e6b54"));

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("9e4bfc5f-65a4-4f92-a5e6-45d7d58b90cb"));

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "RoomTypeId",
                keyValue: new Guid("4b4c0ea5-0b9a-4a20-8ad9-77441fb912d2"));

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "RoomTypeId",
                keyValue: new Guid("5a5de3b8-3ed8-4f0a-bda9-cf73225a64a1"));

            migrationBuilder.DeleteData(
                table: "RoomTypes",
                keyColumn: "RoomTypeId",
                keyValue: new Guid("d67ddbe4-1f1a-4d85-bcc1-ec3a475ecb68"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("af838868-a3e8-47d0-b1a3-8111396dda35"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b748f5b2-6b48-4e5d-9e4b-c5bfa54cb1f2"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("b1f8b3e4-4e30-4c6b-8c4f-2c9c9de7d517"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("c2f87e1e-3cf0-4c3e-b09b-bb2d8e5b74b9"));

            migrationBuilder.DeleteData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("4b72f22b-4a11-44d0-a62d-8a5c5cf3e7a1"));
        }
    }
}
