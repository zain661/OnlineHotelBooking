using HotelBooking.Application.Abstractions;
using HotelBooking.Application.DTOs.Booking.Responses;
using System.Text;

namespace HotelBooking.Infrastructure.Services
{
    public class InvoiceService : IInvoiceService
    {
        public string GenerateInvoiceHtml(CheckoutResult invoice, string userName)
        {
            var sb = new StringBuilder();

            sb.Append(@"<!DOCTYPE html>
                <html lang=""en"">
                <head>
                    <meta charset=""UTF-8"">
                    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                    <title>Hotel Invoice</title>
                    <style>
                        body { font-family: Arial, sans-serif; margin: 20px; }
                        table { width: 100%; border-collapse: collapse; margin-top: 20px; }
                        th, td { border: 1px solid #dddddd; text-align: left; padding: 8px; }
                        th { background-color: #f2f2f2; }
                        .total { font-weight: bold; }
                    </style>
                </head>
                <body>
                <h1>Hotel Invoice</h1>
                <p>Booking Number: <strong>").Append(invoice.ConfirmationNumber).Append(@"</strong></p>
                <p>Hotel Address: <strong>").Append(string.Join(", ", invoice.HotelAddress)).Append(@"</strong></p>
                <p>Guest Name: <strong>").Append(userName).Append(@"</strong></p>
                <p>Check-In Date: <strong>").Append(invoice.CheckInDate.ToString("yyyy/MM/dd")).Append(@"</strong></p>
                <p>Check-Out Date: <strong>").Append(invoice.CheckOutDate.ToString("yyyy/MM/dd")).Append(@"</strong></p>
                <p>Payment Status: <strong>").Append(invoice.PaymentStatus).Append(@"</strong></p>
                <table>
                    <thead>
                        <tr><th>Description</th><th>Quantity</th><th>Unit Price</th><th>Total</th></tr>
                    </thead>
                    <tbody>");

            foreach (var roomDetail in invoice.RoomDetails)
            {
                sb.Append(@"<tr><td>").Append(roomDetail.Description).Append(@"</td><td>").Append(roomDetail.Quantity).Append(@"</td><td>$").Append(roomDetail.UnitPrice).Append("</td><td>$").Append(roomDetail.TotalPrice).Append("</td></tr>");
            }

            sb.Append(@"</tbody>
                <tfoot>
                    <tr><td colspan=""3"" style=""text-align: right;"">Total:</td><td>$").Append(invoice.TotalAmount).Append(@"</td></tr>
                </tfoot>
                </table>
                </body>
                </html>");

            return sb.ToString();
        }

    }
}
