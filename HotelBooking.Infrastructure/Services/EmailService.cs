using HotelBooking.Application.Abstractions;
using MailKit.Net.Smtp;
using MimeKit;

namespace HotelBooking.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        public async Task SendInvoiceEmailAsync(string toEmail, string subject, string body, byte[] attachment, string attachmentName)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Zain Hotels", "no-reply@zainhotels.com"));
            message.To.Add(new MailboxAddress("", toEmail));
            message.Subject = subject;

            var builder = new BodyBuilder
            {
                HtmlBody = body
            };

            // Attach the PDF
            builder.Attachments.Add(attachmentName, attachment);

            message.Body = builder.ToMessageBody();

            using var client = new SmtpClient();
            await client.ConnectAsync("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
            await client.AuthenticateAsync("zaynassaf2001@gmail.com", "erwk biiz kgjk awia");
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }
    }
}
