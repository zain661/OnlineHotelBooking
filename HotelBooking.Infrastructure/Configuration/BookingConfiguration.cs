using HotelBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            // Primary key
            builder.HasKey(b => b.Id);

            // Foreign key to User
            builder.HasOne(b => b.User)
                .WithMany(u => u.Bookings)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Dates configuration
            builder.Property(b => b.CheckInDate)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(b => b.CheckOutDate)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(b => b.BookingDate)
                .IsRequired()
                .HasColumnType("datetime");

            // TotalAmount configuration
            builder.Property(b => b.TotalAmount)
                .IsRequired()
                .HasColumnType("float");

            // Relationship with Rooms (Many-to-Many)
            builder.HasMany(b => b.Rooms)
                .WithMany(r => r.Bookings);

            // Relationship with Review (One-to-One)
            builder.HasOne(b => b.Review)
                .WithOne(r => r.Booking)
                .HasForeignKey<Review>(r => r.BookingId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relationship with Payment (One-to-One)
            builder.HasOne(b => b.Payment)
                .WithOne(p => p.Booking)
                .HasForeignKey<Payment>(p => p.BookingId)
                .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            builder.HasIndex(b => b.UserId);
            builder.HasIndex(b => b.CheckInDate);
            builder.HasIndex(b => b.CheckOutDate);

            // Check constraint for CheckInDate to be at least today
            builder
                .HasCheckConstraint(
                    "CK_Booking_CheckInDate",
                    "CheckInDate >= GETDATE()");

            // Check constraint for CheckOutDate to be after CheckInDate
            builder
                .HasCheckConstraint(
                    "CK_Booking_CheckOutDate",
                    "CheckOutDate > CheckInDate");
        }
    }
}
