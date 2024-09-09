using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Enums;

namespace Infrastructure.Seeding;

public class PaymentSeeding
{
    public static IEnumerable<Payment> SeedData()
    {
        return new List<Payment>
        {
            new()
            {
                Id = new Guid("d2e6f4a9-8a7c-4b9e-8f2b-2c7c9d6a3b5e"),
                BookingId = new Guid("7d3155a2-95f8-4d9b-bc24-662ae053f1c9"),
                Amount = 100,
                Status = PaymentStatus.Completed,
                Method = PaymentMethod.CreditCard
            },
            new()
            {
                Id = new Guid("e3f7d5b9-9a8e-4b9e-9d2b-3c8d0e7c4f6e"),
                BookingId = new Guid("efeb3d13-3dab-46c9-aa9a-9f22dd58e06e"),
                Amount = 150,
                Status = PaymentStatus.Pending,
                Method = PaymentMethod.MobileWallet
            },
            new()
            {
                Id = new Guid("f4a8e6c9-0b9d-4b9f-9d3c-4c9e1f8d5a7f"),
                BookingId = new Guid("0bf4a177-98b8-4f67-8a56-95669c320890"),
                Amount = 200,
                Status = PaymentStatus.Cancelled,
                Method = PaymentMethod.Cash
            }
        };
    }
}
