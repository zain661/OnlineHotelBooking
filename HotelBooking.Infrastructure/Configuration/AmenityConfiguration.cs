using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HotelBooking.Domain.Entities;

namespace HotelBooking.Infrastructure.Configurations
{
    public class AmenityConfiguration : IEntityTypeConfiguration<Amenity>
    {
        public void Configure(EntityTypeBuilder<Amenity> builder)
        {
            // Primary key
            builder.HasKey(a => a.Id);

            // Name property configuration
            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Description property configuration
            builder.Property(a => a.Description)
                .HasMaxLength(500);

            // Price property configuration
            builder.Property(a => a.Price)
                .IsRequired()
                .HasColumnType("int");

            builder.HasMany(a => a.RoomTypes)
                .WithMany(rt => rt.Amenities);
            // Indexes
            builder.HasIndex(a => a.Name)
                .IsUnique(); // Ensuring the Amenity name is unique
        }
    }
}
