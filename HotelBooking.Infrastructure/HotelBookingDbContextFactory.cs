using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace HotelBooking.Infrastructure
{
    public class HotelBookingDbContextFactory : IDesignTimeDbContextFactory<HotelBookingDbContext>
    {
        public HotelBookingDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<HotelBookingDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString);

            return new HotelBookingDbContext(optionsBuilder.Options);
        }
    }
}
