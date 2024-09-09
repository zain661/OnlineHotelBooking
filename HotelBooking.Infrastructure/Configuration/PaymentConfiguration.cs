using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Common.Persistence.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder
                .Property(payment => payment.Status)
                .IsRequired()
                .HasConversion(new EnumToStringConverter<PaymentStatus>());

            builder
                .Property(payment => payment.Method)
                .IsRequired()
                .HasConversion(new EnumToStringConverter<PaymentMethod>());

            builder
                .Property(payment => payment.Amount)
                .IsRequired();

            builder
                .HasIndex(payment => payment.Status);

            builder
                .HasIndex(payment => payment.Method);

            builder
                .HasOne<Booking>(payment => payment.Booking)
                .WithOne(booking => booking.Payment)
                .HasForeignKey<Payment>(payment => payment.BookingId);
        }
    }
}
