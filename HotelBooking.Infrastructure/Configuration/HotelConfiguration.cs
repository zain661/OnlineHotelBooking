using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore;

public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
{
    public void Configure(EntityTypeBuilder<Hotel> builder)
    {
        // Primary key
        builder.HasKey(h => h.Id);

        // Name property configuration
        builder.Property(h => h.Name)
            .IsRequired()
            .HasMaxLength(255);

        // Rating property configuration
        builder.Property(h => h.Rating)
            .HasConversion<float>(); // Ensure proper conversion if needed

        // StreetAddress property configuration
        builder.Property(h => h.StreetAddress)
            .IsRequired()
            .HasMaxLength(255);

        // Description property configuration
        builder.Property(h => h.Description)
            .IsRequired()
            .HasMaxLength(1000);

        // PhoneNumber property configuration
        builder.Property(h => h.PhoneNumber)
            .IsRequired()
            .HasMaxLength(20);

        // NumberOfRooms property configuration
        builder.Property(h => h.NumberOfRooms)
            .IsRequired();

        // Category property configuration
        builder.Property(h => h.Category)
            .IsRequired()
            .HasConversion(new EnumToStringConverter<HotelCategory>());

        // Indexes
        builder.HasIndex(h => h.CityId);
        builder.HasIndex(h => h.OwnerId);

        // Relationships
        builder.HasMany(h => h.Images)
            .WithOne(i => i.Hotel)
            .HasForeignKey(i => i.HotelId)
            .OnDelete(DeleteBehavior.Restrict);  // Add OnDelete behavior

        builder.HasMany(h => h.Rooms)
            .WithOne(r => r.Hotel)
            .HasForeignKey(r => r.HotelId)
            .OnDelete(DeleteBehavior.Restrict);  // Add OnDelete behavior

        builder.HasOne(h => h.City)
            .WithMany(c => c.Hotels)
            .HasForeignKey(h => h.CityId)
            .OnDelete(DeleteBehavior.Restrict);  // Add OnDelete behavior

        builder.HasOne(h => h.Owner)
            .WithMany(o => o.Hotels)
            .HasForeignKey(h => h.OwnerId)
            .OnDelete(DeleteBehavior.Restrict);  // Add OnDelete behavior

        // Check constraints
        builder.ToTable(hotel =>
            hotel.HasCheckConstraint("CK_Hotel_RatingRange", "[Rating] >= 0 AND [Rating] <= 5"));
    }
}
