using HotelBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using HotelBooking.Domain.Enums;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

public class RoomTypeConfiguration : IEntityTypeConfiguration<RoomType>
{
    public void Configure(EntityTypeBuilder<RoomType> builder)
    {
        
        builder.HasIndex(roomType => roomType.Category);

        // Primary key
        builder.HasKey(rt => rt.RoomTypeId);

        // Enum to string conversion for RoomCategory
        builder.Property(rt => rt.Category)
            .IsRequired()
            .HasConversion(new EnumToStringConverter<RoomCategory>());

        // PricePerNight configuration
        builder.Property(rt => rt.PricePerNight)
            .IsRequired()
            .HasColumnType("float");

        // Relationship with Amenities (many-to-many)
        builder.HasMany(rt => rt.Amenities)
            .WithMany(a => a.RoomTypes);

        // Relationship with Discounts (one-to-many)
        builder.HasMany(rt => rt.Discounts)
            .WithOne(d => d.RoomType)
            .HasForeignKey(d => d.RoomTypeId)
            .OnDelete(DeleteBehavior.Cascade);

        // Relationship with Rooms (one-to-many)
        builder.HasMany(rt => rt.Rooms)
            .WithOne(r => r.RoomType)
            .HasForeignKey(r => r.RoomTypeId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.ToTable(roomType =>
            roomType.HasCheckConstraint("CK_RoomType_PriceRange", "[PricePerNight] >= 0"));
    }
}
