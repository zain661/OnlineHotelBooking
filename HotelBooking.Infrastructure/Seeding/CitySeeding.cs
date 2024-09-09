using HotelBooking.Domain.Entities;

namespace Infrastructure.Seeding;

public class CitySeeding
{
    public static IEnumerable<City> SeedData()
    {
        return new List<City>
        {
            new()
            {
                Id = new Guid("c2f87e1e-3cf0-4c3e-b09b-bb2d8e5b74b9"),
                Name = "Jenin",
                CountryName = "Palestine",
                PostOffice = "JJJ",
            },
            new()
            {
                Id = new Guid("b1f8b3e4-4e30-4c6b-8c4f-2c9c9de7d517"),
                Name = "Amman",
                CountryName = "Jordan",
                PostOffice = "AAA",
            },
            new()
            {
                Id = new Guid("4a7d5f20-8b3d-4b9c-b9b6-ecb2bbd25e3c"),
                Name = "Gaza",
                CountryName = "Gaza",
                PostOffice = "GGG",
            }
        };
    }
}