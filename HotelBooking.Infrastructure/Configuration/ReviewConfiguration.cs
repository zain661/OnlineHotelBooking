using HotelBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Common.Persistence.Configurations
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder
                .Property(review => review.Comment)
                .HasMaxLength(300)
                .IsRequired();

            builder
                .Property(review => review.Rating)
                .IsRequired();

            builder
                .HasCheckConstraint("CK_Review_RatingRange", "[Rating] >= 0 AND [Rating] <= 5");

            builder
                .HasOne<Booking>(review => review.Booking)
                .WithOne(booking => booking.Review)
                .HasForeignKey<Review>(review => review.BookingId);
        }
    }
}
