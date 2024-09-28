using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelBooking.Domain.Entities;
using HotelBooking.Infrastructure;
using HotelBooking.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace HotelBooking.UnitTests
{
    public class CityRepoTests : IDisposable
    {
        private readonly HotelBookingDbContext _dbContext;
        private readonly CityRepo _cityRepo;

        public CityRepoTests()
        {
            // Setup in-memory database
            var options = new DbContextOptionsBuilder<HotelBookingDbContext>()
                .UseInMemoryDatabase(databaseName: "HotelBookingTestDb")
                .Options;

            _dbContext = new HotelBookingDbContext(options);

            // Seed the database with initial data
            _dbContext.Cities.AddRange(
    new City { Id = Guid.NewGuid(), Name = "City1", CountryName = "Country1", PostOffice = "11111" },
    new City { Id = Guid.NewGuid(), Name = "City2", CountryName = "Country2", PostOffice = "22222" }
);

            _dbContext.SaveChanges();

            _cityRepo = new CityRepo(_dbContext);
        }

        public void Dispose()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Dispose();
        }

        [Fact]
        public async Task AddCityAsync_ShouldAddCitySuccessfully()
        {
            // Arrange
            var city = new City
            {
                Id = Guid.NewGuid(),
                Name = "New City",
                CountryName = "Country X", // Ensure all required properties are set
                PostOffice = "12345"       // Ensure all required properties are set
            };

            // Act
            var result = await _cityRepo.AddCityAsync(city);

            // Assert
            var addedCity = await _dbContext.Cities.FindAsync(city.Id);
            Assert.NotNull(addedCity);
            Assert.Equal("New City", addedCity.Name);
            Assert.Equal("Country X", addedCity.CountryName);
            Assert.Equal("12345", addedCity.PostOffice);
        }


        [Fact]
        public async Task GetAllCitiesAsync_ShouldReturnAllCities()
        {
            // Act
            var result = await _cityRepo.GetAllCitiesAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());  // Expecting 2 cities in the database
        }

        [Fact]
        public async Task GetCityByIdAsync_ShouldReturnCity()
        {
            // Arrange
            var city = _dbContext.Cities.First();
            var cityId = city.Id;

            // Act
            var result = await _cityRepo.GetCityByIdAsync(cityId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(cityId, result.Id);
        }

        [Fact]
        public async Task UpdateCityAsync_ShouldUpdateCitySuccessfully()
        {
            // Arrange
            var city = _dbContext.Cities.First();
            city.Name = "Updated City";

            // Act
            var result = await _cityRepo.UpdateCityAsync(city);

            // Assert
            var updatedCity = await _dbContext.Cities.FindAsync(city.Id);
            Assert.NotNull(updatedCity);
            Assert.Equal("Updated City", updatedCity.Name);
        }

        [Fact]
        public async Task DeleteCityAsync_ShouldRemoveCitySuccessfully()
        {
            // Arrange
            var city = _dbContext.Cities.First();
            var cityId = city.Id;

            // Act
            var result = await _cityRepo.DeleteCityAsync(cityId);

            // Assert
            var deletedCity = await _dbContext.Cities.FindAsync(cityId);
            Assert.True(result);
            Assert.Null(deletedCity);
        }
    }
}
