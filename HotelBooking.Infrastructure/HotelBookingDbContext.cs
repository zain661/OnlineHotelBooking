using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Enums;
using HotelBooking.Infrastructure.Configurations;
using HotelBooking.Infrastructure.Persistence.Configurations;
using Infrastructure.Common.Persistence.Configurations;
using Infrastructure.Configurations;
using Infrastructure.Seeding;
using InfrastructureSeeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;

namespace HotelBooking.Infrastructure
{
    public class HotelBookingDbContext : DbContext
    {
        public HotelBookingDbContext(DbContextOptions<HotelBookingDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Payment> Payment { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new OwnerConfiguration());
            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new HotelConfiguration());
            modelBuilder.ApplyConfiguration(new RoomConfiguration());
            modelBuilder.ApplyConfiguration(new RoomTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BookingConfiguration());
            modelBuilder.ApplyConfiguration(new AmenityConfiguration());
            modelBuilder.ApplyConfiguration(new ImageConfiguration());
            modelBuilder.ApplyConfiguration(new DiscountConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentConfiguration());
            modelBuilder.ApplyConfiguration(new ReviewConfiguration());

            modelBuilder.Entity<User>().HasData(UserSeeding.SeedData());
            modelBuilder.Entity<Owner>().HasData(OwnerSeeding.SeedData());
            modelBuilder.Entity<City>().HasData(CitySeeding.SeedData());
            modelBuilder.Entity<Hotel>().HasData(HotelSeeding.SeedData());
            modelBuilder.Entity<Room>().HasData(RoomSeeding.SeedData());
            modelBuilder.Entity<RoomType>().HasData(RoomTypeSeeding.SeedData());
            modelBuilder.Entity<Booking>().HasData(BookingSeeding.SeedData());
            modelBuilder.Entity("BookingRoom").HasData(BookingRoomSeeding.SeedData());
            modelBuilder.Entity<Amenity>().HasData(AmenitySeeding.SeedData());
            modelBuilder.Entity<Discount>().HasData(DiscountSeeding.SeedData());
            // Seeding the many-to-many relationship between Amenity and RoomType
            modelBuilder.Entity("AmenityRoomType").HasData(AmenityRoomTypeSeeding.SeedData());
            modelBuilder.Entity<Image>().HasData(ImageSeeding.SeedData());
            modelBuilder.Entity<Payment>().HasData(PaymentSeeding.SeedData());
            modelBuilder.Entity<Review>().HasData(ReviewSeeding.SeedData());

            base.OnModelCreating(modelBuilder);
        }




    }
}
