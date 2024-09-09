using HotelBooking.Application.DTOs.Booking.Responses;

namespace HotelBooking.Application.Abstractions
{
    public interface IInvoiceService
    {
        string GenerateInvoiceHtml(CheckoutResult invoice, string userName);
    }
}
