using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Enums;
using HotelBooking.Domain.Interfaces;
using HotelBooking.Infrastructure;
using HotelBooking.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.UnitTests
{
    public class ImageRepoTests : IDisposable
    {
        private readonly HotelBookingDbContext _dbContext;
        private readonly ImageRepo _imageRepo;
        public ImageRepoTests()
        {
            var options = new DbContextOptionsBuilder<HotelBookingDbContext>()
                .UseInMemoryDatabase(databaseName: "HotelBookingTestDb")
                .Options;

            _dbContext = new HotelBookingDbContext(options);

            // Seed the database with initial data
            var hotelId = Guid.NewGuid();
            var cityId = Guid.NewGuid();

            _dbContext.Hotels.Add(new Hotel
            {
                Id = hotelId,
                Name = "Test Hotel",
                CityId = cityId,
                StreetAddress = "123 Test St.",
                PhoneNumber = "123-456-7890",
                NumberOfRooms = 10,
                Description = "A test hotel for integration testing", // Add this line
                CreatedAt = DateTime.Now
            });


            _dbContext.Images.AddRange(
                new Image
                {
                    Id = Guid.NewGuid(),
                    Url = "https://example.com/hotel1.jpg",
                    Type = Domain.Enums.ImageType.Gallery,
                    Format = Domain.Enums.ImageFormat.Jpg,
                    HotelId = hotelId,
                    OwnerType = Domain.Enums.ImageOwnerType.Hotel
                },
                new Image
                {
                    Id = Guid.NewGuid(),
                    Url = "https://example.com/hotel2.jpg",
                    Type = Domain.Enums.ImageType.Thumbnail,
                    Format = Domain.Enums.ImageFormat.Jpg,
                    HotelId = hotelId,
                    OwnerType = Domain.Enums.ImageOwnerType.Hotel
                }
            );

            _dbContext.SaveChanges();

            _imageRepo = new ImageRepo(_dbContext);
        }

        [Fact]
        public async Task GetImagesByHotelIdAsync_ShouldReturnImagesForHotel()
        {
            // Arrange
            var hotelId = _dbContext.Hotels.First().Id;

            // Act
            var images = await _imageRepo.GetImagesByHotelIdAsync(hotelId);

            // Assert
            Assert.NotNull(images);
            Assert.Equal(2, images.Count);
            Assert.All(images, img => Assert.Equal(hotelId, img.HotelId));
        }

        public void Dispose()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Dispose();
        }

    }
}
