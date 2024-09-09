using HotelBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Infrastructure.Configurations;

public class RoomConfiguration : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        // Primary key
        builder.HasKey(r => r.Id);

        // Capacity fields configuration
        builder.Property(r => r.AdultsCapacity)
            .IsRequired()
            .HasColumnType("int");

        builder.Property(r => r.ChildrenCapacity)
            .IsRequired()
            .HasColumnType("int");

        // Rating configuration
        builder.Property(r => r.Rating)
            .IsRequired()
            .HasColumnType("float");

        // Foreign key to Hotel
        builder.HasOne(r => r.Hotel)
            .WithMany(h => h.Rooms)
            .HasForeignKey(r => r.HotelId)
            .OnDelete(DeleteBehavior.Cascade);

        // Optional foreign key to RoomType
        builder.HasOne(r => r.RoomType)
            .WithMany(rt => rt.Rooms)
            .HasForeignKey(r => r.RoomTypeId)
            .OnDelete(DeleteBehavior.SetNull);

        // Relationship with Bookings
        builder.HasMany(r => r.Bookings)
            .WithMany(b => b.Rooms);

        // Indexes
        builder.HasIndex(r => r.HotelId);
        builder.HasIndex(r => r.RoomTypeId);

        builder.ToTable(room =>
            room
            .HasCheckConstraint
            ("CK_Review_RatingRange", "[Rating] >= 0 AND [Rating] <= 5"));
    }
}