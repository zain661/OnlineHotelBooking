using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelBooking.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addReviewAndPaymentTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Bookings_BookingId",
                table: "Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Review",
                table: "Review");

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

            migrationBuilder.RenameTable(
                name: "Review",
                newName: "Reviews");

            migrationBuilder.RenameIndex(
                name: "IX_Review_BookingId",
                table: "Reviews",
                newName: "IX_Reviews_BookingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: new Guid("a1aebf1a-5c85-4e54-81a7-2b59c3d1d3b8"),
                columns: new[] { "FromDate", "ToDate" },
                values: new object[] { new DateTime(2024, 8, 18, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 9, 7, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: new Guid("b3f70a88-53e5-4b35-9d08-59632cfaf872"),
                columns: new[] { "FromDate", "ToDate" },
                values: new object[] { new DateTime(2024, 8, 23, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: new Guid("c6d14b29-1d59-42ab-b13f-15d5939e4ae4"),
                columns: new[] { "FromDate", "ToDate" },
                values: new object[] { new DateTime(2024, 8, 26, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 9, 4, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CityId", "Format", "HotelId", "OwnerType", "Type", "Url" },
                values: new object[,]
                {
                    { new Guid("18f12338-e555-44c9-bd3b-dec0332e40fb"), null, "Jpg", new Guid("e4a5d378-6a32-4b7e-917f-51c5798e6b54"), "Hotel", "Gallery", "https://aabhariindia.com/assets/image/9.jpg" },
                    { new Guid("1a9d6462-75b6-4625-a113-e0d5c1f97663"), null, "Jpg", new Guid("b8f4d9a7-73e9-4536-890e-71f1f9cfe9f2"), "Hotel", "Thumbnail", "https://images.pexels.com/photos/189296/pexels-photo-189296.jpeg?cs=srgb&dl=pexels-donaldtong94-189296.jpg&fm=jpg" },
                    { new Guid("358b3590-37b8-404f-bc99-54ba79a37217"), null, "Jpg", new Guid("9a0d6e3b-5d48-489e-a9f2-743c0fcd83b1"), "Hotel", "Gallery", "https://watermark.lovepik.com/photo/20211123/large/lovepik-malaysia-luxury-resort-hotel-picture_500865089.jpg" },
                    { new Guid("751e8ba8-3770-4aa8-aee9-2e9cc60c2eab"), new Guid("c2f87e1e-3cf0-4c3e-b09b-bb2d8e5b74b9"), "Png", null, "City", "Thumbnail", "https://example.com/image2.png" },
                    { new Guid("9f4bf62c-b939-46d6-b570-61d7edeb7ddf"), new Guid("4a7d5f20-8b3d-4b9c-b9b6-ecb2bbd25e3c"), "Png", null, "City", "Gallery", "https://example.com/image5.png" },
                    { new Guid("e6deb3e9-cc99-42c8-ac06-b58a9032a6fb"), new Guid("b1f8b3e4-4e30-4c6b-8c4f-2c9c9de7d517"), "Png", null, "City", "Thumbnail", "https://example.com/image4.png" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Bookings_BookingId",
                table: "Reviews",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Bookings_BookingId",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews");

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("18f12338-e555-44c9-bd3b-dec0332e40fb"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("1a9d6462-75b6-4625-a113-e0d5c1f97663"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("358b3590-37b8-404f-bc99-54ba79a37217"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("751e8ba8-3770-4aa8-aee9-2e9cc60c2eab"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("9f4bf62c-b939-46d6-b570-61d7edeb7ddf"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("e6deb3e9-cc99-42c8-ac06-b58a9032a6fb"));

            migrationBuilder.RenameTable(
                name: "Reviews",
                newName: "Review");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_BookingId",
                table: "Review",
                newName: "IX_Review_BookingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Review",
                table: "Review",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: new Guid("a1aebf1a-5c85-4e54-81a7-2b59c3d1d3b8"),
                columns: new[] { "FromDate", "ToDate" },
                values: new object[] { new DateTime(2024, 8, 17, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 9, 6, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: new Guid("b3f70a88-53e5-4b35-9d08-59632cfaf872"),
                columns: new[] { "FromDate", "ToDate" },
                values: new object[] { new DateTime(2024, 8, 22, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: new Guid("c6d14b29-1d59-42ab-b13f-15d5939e4ae4"),
                columns: new[] { "FromDate", "ToDate" },
                values: new object[] { new DateTime(2024, 8, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 9, 3, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CityId", "Format", "HotelId", "OwnerType", "Type", "Url" },
                values: new object[,]
                {
                    { new Guid("3b5769cd-ce5c-449c-917a-9bd218749021"), null, "Jpg", new Guid("e4a5d378-6a32-4b7e-917f-51c5798e6b54"), "Hotel", "Gallery", "https://aabhariindia.com/assets/image/9.jpg" },
                    { new Guid("513e98e7-ed70-42ac-a3de-8da2eeacc809"), new Guid("4a7d5f20-8b3d-4b9c-b9b6-ecb2bbd25e3c"), "Png", null, "City", "Gallery", "https://example.com/image5.png" },
                    { new Guid("540ea76c-4773-46e7-a847-924ddf3a6036"), new Guid("c2f87e1e-3cf0-4c3e-b09b-bb2d8e5b74b9"), "Png", null, "City", "Thumbnail", "https://example.com/image2.png" },
                    { new Guid("6ac0f39a-edda-4ea8-941f-35679fd704ee"), null, "Jpg", new Guid("9a0d6e3b-5d48-489e-a9f2-743c0fcd83b1"), "Hotel", "Gallery", "https://watermark.lovepik.com/photo/20211123/large/lovepik-malaysia-luxury-resort-hotel-picture_500865089.jpg" },
                    { new Guid("76414f7f-1a4b-4868-b9de-0a3b59290700"), null, "Jpg", new Guid("b8f4d9a7-73e9-4536-890e-71f1f9cfe9f2"), "Hotel", "Thumbnail", "https://images.pexels.com/photos/189296/pexels-photo-189296.jpeg?cs=srgb&dl=pexels-donaldtong94-189296.jpg&fm=jpg" },
                    { new Guid("78d5b776-b6ac-4cb6-843b-2a1b8ffda097"), new Guid("b1f8b3e4-4e30-4c6b-8c4f-2c9c9de7d517"), "Png", null, "City", "Thumbnail", "https://example.com/image4.png" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Bookings_BookingId",
                table: "Review",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
