using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Enums;

public class ImageSeeding
{
    public static IEnumerable<Image> SeedData()
    {
        return new List<Image>
        {
            new() {
                Id = Guid.NewGuid(),
                Url = "https://aabhariindia.com/assets/image/9.jpg",
                Type = ImageType.Gallery,
                Format = ImageFormat.Jpg,
                OwnerType = ImageOwnerType.Hotel,
                HotelId = new Guid("e4a5d378-6a32-4b7e-917f-51c5798e6b54") // Copied directly from the query result
            },
            new() {
                Id = Guid.NewGuid(),
                Url = "https://images.pexels.com/photos/189296/pexels-photo-189296.jpeg?cs=srgb&dl=pexels-donaldtong94-189296.jpg&fm=jpg",
                Type = ImageType.Thumbnail,
                Format = ImageFormat.Jpg,
                OwnerType = ImageOwnerType.Hotel,
                HotelId = new Guid("b8f4d9a7-73e9-4536-890e-71f1f9cfe9f2") // Copied directly from the query result
            },
            new() {
                Id = Guid.NewGuid(),
                Url = "https://watermark.lovepik.com/photo/20211123/large/lovepik-malaysia-luxury-resort-hotel-picture_500865089.jpg",
                Type = ImageType.Gallery,
                Format = ImageFormat.Jpg,
                OwnerType = ImageOwnerType.Hotel,
                HotelId = new Guid("9a0d6e3b-5d48-489e-a9f2-743c0fcd83b1") // Copied directly from the query result
            },
            new()
            {
                Id = Guid.NewGuid(),
                Url = "https://example.com/image2.png",
                Type = ImageType.Thumbnail,
                Format = ImageFormat.Png,
                OwnerType = ImageOwnerType.City,
                CityId = new Guid("c2f87e1e-3cf0-4c3e-b09b-bb2d8e5b74b9")
            },
            new()
            {
                Id = Guid.NewGuid(),
                Url = "https://example.com/image4.png",
                Type = ImageType.Thumbnail,
                Format = ImageFormat.Png,
                OwnerType = ImageOwnerType.City,
                CityId = new Guid("b1f8b3e4-4e30-4c6b-8c4f-2c9c9de7d517")
            },
            new()
            {
                Id = Guid.NewGuid(),
                Url = "https://example.com/image5.png",
                Type = ImageType.Gallery,
                Format = ImageFormat.Png,
                OwnerType = ImageOwnerType.City,
                CityId = new Guid("4a7d5f20-8b3d-4b9c-b9b6-ecb2bbd25e3c")
            }
        };
    }
}
