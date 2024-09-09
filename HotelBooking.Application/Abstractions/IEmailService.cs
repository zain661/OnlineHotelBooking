namespace HotelBooking.Application.Abstractions
{
    public interface IEmailService
    {
        Task SendInvoiceEmailAsync(string toEmail, string subject, string body, byte[] attachment, string attachmentName);
    }
}
