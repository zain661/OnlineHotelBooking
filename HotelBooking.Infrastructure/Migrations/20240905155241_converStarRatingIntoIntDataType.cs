using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelBooking.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class converStarRatingIntoIntDataType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("3c6917ce-4dbd-43c4-a175-138e9d660213"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("7660e493-d9ec-4bc8-b6dd-63f916a1fd89"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("841a0a03-f6e6-4581-8c62-5d61d5ab0012"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("c0c88162-fc33-4b0e-8060-f146a593cf2b"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("d9004ebc-b656-4b75-82d7-eca227ca9754"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("ea084f61-7129-48a7-82d7-4ce7babba07c"));

            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "Hotels",
                newName: "StarRate");

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: new Guid("a1aebf1a-5c85-4e54-81a7-2b59c3d1d3b8"),
                columns: new[] { "FromDate", "ToDate" },
                values: new object[] { new DateTime(2024, 8, 26, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 9, 15, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: new Guid("b3f70a88-53e5-4b35-9d08-59632cfaf872"),
                columns: new[] { "FromDate", "ToDate" },
                values: new object[] { new DateTime(2024, 8, 31, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: new Guid("c6d14b29-1d59-42ab-b13f-15d5939e4ae4"),
                columns: new[] { "FromDate", "ToDate" },
                values: new object[] { new DateTime(2024, 9, 3, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 9, 12, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("9a0d6e3b-5d48-489e-a9f2-743c0fcd83b1"),
                column: "StarRate",
                value: 4f);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("b8f4d9a7-73e9-4536-890e-71f1f9cfe9f2"),
                column: "StarRate",
                value: 3f);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("e4a5d378-6a32-4b7e-917f-51c5798e6b54"),
                column: "StarRate",
                value: 4f);

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CityId", "Format", "HotelId", "OwnerType", "Type", "Url" },
                values: new object[,]
                {
                    { new Guid("082430f5-0398-4731-9448-90df439877ba"), null, "Jpg", new Guid("b8f4d9a7-73e9-4536-890e-71f1f9cfe9f2"), "Hotel", "Thumbnail", "https://images.pexels.com/photos/189296/pexels-photo-189296.jpeg?cs=srgb&dl=pexels-donaldtong94-189296.jpg&fm=jpg" },
                    { new Guid("41a73edd-d9b6-426d-b41d-d42fd1588d4b"), new Guid("b1f8b3e4-4e30-4c6b-8c4f-2c9c9de7d517"), "Png", null, "City", "Thumbnail", "https://example.com/image4.png" },
                    { new Guid("856f943e-a31c-4903-a05e-f67aeb5c3cc3"), new Guid("c2f87e1e-3cf0-4c3e-b09b-bb2d8e5b74b9"), "Png", null, "City", "Thumbnail", "https://example.com/image2.png" },
                    { new Guid("8ec5dd40-186d-42c4-9d27-b69045246f54"), new Guid("4a7d5f20-8b3d-4b9c-b9b6-ecb2bbd25e3c"), "Png", null, "City", "Gallery", "https://example.com/image5.png" },
                    { new Guid("b8d5bc0b-b1ce-40d1-a3ca-8a686c6ce618"), null, "Jpg", new Guid("e4a5d378-6a32-4b7e-917f-51c5798e6b54"), "Hotel", "Gallery", "https://aabhariindia.com/assets/image/9.jpg" },
                    { new Guid("c2e42066-38cf-43df-93bd-ee1c58c552ff"), null, "Jpg", new Guid("9a0d6e3b-5d48-489e-a9f2-743c0fcd83b1"), "Hotel", "Gallery", "https://watermark.lovepik.com/photo/20211123/large/lovepik-malaysia-luxury-resort-hotel-picture_500865089.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("082430f5-0398-4731-9448-90df439877ba"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("41a73edd-d9b6-426d-b41d-d42fd1588d4b"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("856f943e-a31c-4903-a05e-f67aeb5c3cc3"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("8ec5dd40-186d-42c4-9d27-b69045246f54"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("b8d5bc0b-b1ce-40d1-a3ca-8a686c6ce618"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("c2e42066-38cf-43df-93bd-ee1c58c552ff"));

            migrationBuilder.RenameColumn(
                name: "StarRate",
                table: "Hotels",
                newName: "Rating");

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: new Guid("a1aebf1a-5c85-4e54-81a7-2b59c3d1d3b8"),
                columns: new[] { "FromDate", "ToDate" },
                values: new object[] { new DateTime(2024, 8, 25, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 9, 14, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: new Guid("b3f70a88-53e5-4b35-9d08-59632cfaf872"),
                columns: new[] { "FromDate", "ToDate" },
                values: new object[] { new DateTime(2024, 8, 30, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 9, 9, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: new Guid("c6d14b29-1d59-42ab-b13f-15d5939e4ae4"),
                columns: new[] { "FromDate", "ToDate" },
                values: new object[] { new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2024, 9, 11, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("9a0d6e3b-5d48-489e-a9f2-743c0fcd83b1"),
                column: "Rating",
                value: 4.2f);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("b8f4d9a7-73e9-4536-890e-71f1f9cfe9f2"),
                column: "Rating",
                value: 3.8f);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("e4a5d378-6a32-4b7e-917f-51c5798e6b54"),
                column: "Rating",
                value: 4.5f);

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CityId", "Format", "HotelId", "OwnerType", "Type", "Url" },
                values: new object[,]
                {
                    { new Guid("3c6917ce-4dbd-43c4-a175-138e9d660213"), new Guid("4a7d5f20-8b3d-4b9c-b9b6-ecb2bbd25e3c"), "Png", null, "City", "Gallery", "https://example.com/image5.png" },
                    { new Guid("7660e493-d9ec-4bc8-b6dd-63f916a1fd89"), new Guid("b1f8b3e4-4e30-4c6b-8c4f-2c9c9de7d517"), "Png", null, "City", "Thumbnail", "https://example.com/image4.png" },
                    { new Guid("841a0a03-f6e6-4581-8c62-5d61d5ab0012"), null, "Jpg", new Guid("e4a5d378-6a32-4b7e-917f-51c5798e6b54"), "Hotel", "Gallery", "https://aabhariindia.com/assets/image/9.jpg" },
                    { new Guid("c0c88162-fc33-4b0e-8060-f146a593cf2b"), new Guid("c2f87e1e-3cf0-4c3e-b09b-bb2d8e5b74b9"), "Png", null, "City", "Thumbnail", "https://example.com/image2.png" },
                    { new Guid("d9004ebc-b656-4b75-82d7-eca227ca9754"), null, "Jpg", new Guid("9a0d6e3b-5d48-489e-a9f2-743c0fcd83b1"), "Hotel", "Gallery", "https://watermark.lovepik.com/photo/20211123/large/lovepik-malaysia-luxury-resort-hotel-picture_500865089.jpg" },
                    { new Guid("ea084f61-7129-48a7-82d7-4ce7babba07c"), null, "Jpg", new Guid("b8f4d9a7-73e9-4536-890e-71f1f9cfe9f2"), "Hotel", "Thumbnail", "https://images.pexels.com/photos/189296/pexels-photo-189296.jpeg?cs=srgb&dl=pexels-donaldtong94-189296.jpg&fm=jpg" }
                });
        }
    }
}
