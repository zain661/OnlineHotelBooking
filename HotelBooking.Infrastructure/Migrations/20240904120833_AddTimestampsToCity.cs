using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelBooking.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTimestampsToCity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Rooms",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Rooms",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Hotels",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Hotels",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Cities",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "Cities",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("4a7d5f20-8b3d-4b9c-b9b6-ecb2bbd25e3c"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("b1f8b3e4-4e30-4c6b-8c4f-2c9c9de7d517"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("c2f87e1e-3cf0-4c3e-b09b-bb2d8e5b74b9"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

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
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("b8f4d9a7-73e9-4536-890e-71f1f9cfe9f2"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("e4a5d378-6a32-4b7e-917f-51c5798e6b54"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

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

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("4e1cb3d9-bc3b-4997-a3d5-0c56cf17fe7a"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("a98b8a9d-4c5a-4a90-a2d2-5f1441b93db6"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("c6898b7e-ee09-4b36-8b20-22e8c2a63e29"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "Cities");

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
        }
    }
}
