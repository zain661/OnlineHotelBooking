using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelBooking.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class converRatingIntoIntDataType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CityId", "Format", "HotelId", "OwnerType", "Type", "Url" },
                values: new object[,]
                {
                    { new Guid("2bef1b9a-9347-4785-80c8-9be5e7fd6827"), new Guid("4a7d5f20-8b3d-4b9c-b9b6-ecb2bbd25e3c"), "Png", null, "City", "Gallery", "https://example.com/image5.png" },
                    { new Guid("5b326737-9b37-4cce-a7ee-62a6f0b34bcf"), new Guid("b1f8b3e4-4e30-4c6b-8c4f-2c9c9de7d517"), "Png", null, "City", "Thumbnail", "https://example.com/image4.png" },
                    { new Guid("812f6324-fb7a-486b-9823-8718fa3a76f4"), null, "Jpg", new Guid("e4a5d378-6a32-4b7e-917f-51c5798e6b54"), "Hotel", "Gallery", "https://aabhariindia.com/assets/image/9.jpg" },
                    { new Guid("86bcc156-b0e9-42c3-bc6c-84a483bce329"), null, "Jpg", new Guid("b8f4d9a7-73e9-4536-890e-71f1f9cfe9f2"), "Hotel", "Thumbnail", "https://images.pexels.com/photos/189296/pexels-photo-189296.jpeg?cs=srgb&dl=pexels-donaldtong94-189296.jpg&fm=jpg" },
                    { new Guid("8edf1cc5-8e1c-46e7-8d36-692b87e30b61"), new Guid("c2f87e1e-3cf0-4c3e-b09b-bb2d8e5b74b9"), "Png", null, "City", "Thumbnail", "https://example.com/image2.png" },
                    { new Guid("9a7f1bdc-fcd4-46f9-ac32-f8f12d3415a7"), null, "Jpg", new Guid("9a0d6e3b-5d48-489e-a9f2-743c0fcd83b1"), "Hotel", "Gallery", "https://watermark.lovepik.com/photo/20211123/large/lovepik-malaysia-luxury-resort-hotel-picture_500865089.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("2bef1b9a-9347-4785-80c8-9be5e7fd6827"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("5b326737-9b37-4cce-a7ee-62a6f0b34bcf"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("812f6324-fb7a-486b-9823-8718fa3a76f4"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("86bcc156-b0e9-42c3-bc6c-84a483bce329"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("8edf1cc5-8e1c-46e7-8d36-692b87e30b61"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("9a7f1bdc-fcd4-46f9-ac32-f8f12d3415a7"));

            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "Hotels",
                newName: "StarRate");

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
    }
}
