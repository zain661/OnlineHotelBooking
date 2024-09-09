using HotelBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelBooking.Infrastructure.Persistence.Configurations
{
    public class DiscountConfiguration : IEntityTypeConfiguration<Discount>
    {
        public void Configure(EntityTypeBuilder<Discount> builder)
        {
            // Set the primary key
            builder.HasKey(d => d.Id);

            // Configure the relationship with RoomType
            builder.HasOne(d => d.RoomType)
                   .WithMany(rt => rt.Discounts)
                   .HasForeignKey(d => d.RoomTypeId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Configure the DiscountPercentage to have a precision (optional)
            builder.Property(d => d.DiscountPercentage)
                   .IsRequired();

            // Configure the FromDate and ToDate fields
            builder.Property(d => d.FromDate)
                   .IsRequired();
            builder.Property(d => d.ToDate)
                   .IsRequired();
        }
    }
}
