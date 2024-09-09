using HotelBooking.Domain.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore;
using HotelBooking.Domain.Entities;

public class ImageConfiguration : IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> builder)
    {
        builder.HasKey(i => i.Id);

        builder.Property(i => i.Url)
            .IsRequired()
            .HasMaxLength(2048);

        builder.Property(i => i.Type)
            .HasConversion(new EnumToStringConverter<ImageType>());

        builder.Property(i => i.Format)
            .HasConversion(new EnumToStringConverter<ImageFormat>());

        builder.Property(i => i.OwnerType)
            .IsRequired()
            .HasConversion(new EnumToStringConverter<ImageOwnerType>());

        // Relation with Hotel
        builder.HasOne(i => i.Hotel)
            .WithMany(h => h.Images)
            .HasForeignKey(i => i.HotelId)
            .OnDelete(DeleteBehavior.Restrict)  // Change to Restrict
            .IsRequired(false);

        // Relation with City
        builder.HasOne(i => i.City)
            .WithMany(c => c.Images)
            .HasForeignKey(i => i.CityId)
            .OnDelete(DeleteBehavior.Restrict)  // Change to Restrict
            .IsRequired(false);

        // Ensure either HotelId or CityId has a value, not both or neither
        builder.HasCheckConstraint("CK_Image_HotelOrCity",
            "[HotelId] IS NULL AND [CityId] IS NOT NULL OR [HotelId] IS NOT NULL AND [CityId] IS NULL");
    }
}
