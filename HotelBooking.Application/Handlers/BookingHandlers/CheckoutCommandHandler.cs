using FluentValidation;
using HotelBooking.Application.Abstractions;
using HotelBooking.Application.Commands.BookingCommands;
using HotelBooking.Application.DTOs.Booking.Responses;
using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Enums;
using HotelBooking.Domain.Interfaces;
using MediatR;

namespace HotelBooking.Application.Handlers.BookingHandlers
{
    public class CheckoutCommandHandler : IRequestHandler<CheckoutCommand, CheckoutResult>
    {
        private readonly IBookingRepo _bookingRepo;
        private readonly IRoomRepo _roomRepo;
        private readonly IPdfService _pdfService;
        private readonly IInvoiceService _invoiceService;
        private readonly IEmailService _emailService;
        private readonly IValidator<CheckoutCommand> _validator;

        public CheckoutCommandHandler(
            IBookingRepo bookingRepo,
            IRoomRepo roomRepo,
            IPdfService pdfService,
            IInvoiceService invoiceService,
            IEmailService emailService,
            IValidator<CheckoutCommand> validator)
        {
            _bookingRepo = bookingRepo;
            _roomRepo = roomRepo;
            _pdfService = pdfService;
            _invoiceService = invoiceService;
            _emailService = emailService;
            _validator = validator;
        }

        public async Task<CheckoutResult> Handle(CheckoutCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                // Handle validation failures
                return null; // or return a result indicating validation errors
            }
            // Validate the rooms availability
            var roomIds = request.RoomSelections.Select(rs => rs.RoomId).ToList();
            var rooms = await _roomRepo.GetAvailableRoomsByIdsAsync(roomIds, request.CheckInDate, request.CheckOutDate);

            if (!rooms.Any() || rooms.Count != request.RoomSelections.Count)
            {
                return null;
            }


            // Join room details with user-provided prices and calculate total amount
            var roomDetails = from room in rooms
                              join selection in request.RoomSelections
                              on room.Id equals selection.RoomId
                              group new { room, selection } by new
                              {
                                  room.RoomType.Category,
                                  HotelName = room.Hotel.Name,
                                  UserProvidedPricePerNight = selection.PricePerNight
                              } into g
                              select new RoomDetail
                              {
                                  Description = $"{g.Key.Category} in {g.Key.HotelName}",
                                  Quantity = g.Count(),
                                  UnitPrice = g.Key.UserProvidedPricePerNight,
                                  TotalPrice = g.Count() * g.Key.UserProvidedPricePerNight
                              };

            // Calculate the total amount based on room details
            var totalAmount = roomDetails.Sum(rd => rd.TotalPrice);

            // Create booking with the calculated total amount
            var booking = new Booking
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                CheckInDate = request.CheckInDate,
                CheckOutDate = request.CheckOutDate,
                BookingDate = DateTime.UtcNow,
                TotalAmount = totalAmount, // Use the calculated total amount
                Rooms = rooms,
                Payment = new Payment
                {
                    Id = Guid.NewGuid(),
                    Method = request.PaymentMethod,
                    Status = PaymentStatus.Completed,
                    Amount = totalAmount, // Use the calculated total amount
                }
            };

            await _bookingRepo.AddAsync(booking);

            var hotelAddresses = rooms.Select(r => $"{r.Hotel.City.Name}").Distinct().ToList();

            var result = new CheckoutResult
            {
                ConfirmationNumber = booking.Id.ToString(),
                HotelAddress = hotelAddresses,
                RoomDetails = roomDetails.ToList(),
                CheckInDate = booking.CheckInDate,
                CheckOutDate = booking.CheckOutDate,
                TotalAmount = totalAmount, // Use the calculated total amount
                PaymentStatus = booking.Payment.Status.ToString()
            };

            var userName = request.UserName;
            // Generate Invoice HTML
            var invoiceHtml = _invoiceService.GenerateInvoiceHtml(result, userName);

            // Convert to PDF
            var pdfBytes = await _pdfService.CreatePdfFromHtmlAsync(invoiceHtml);
            var pdfFilePath = Path.Combine("C:/Users/2024/Downloads", $"{booking.Id}.pdf");
            await File.WriteAllBytesAsync(pdfFilePath, pdfBytes, cancellationToken);

            result.PdfUrl = pdfFilePath;
            
            var emailSubject = "Your Hotel Booking Confirmation";
            var emailBody = $"Dear {userName},<br><br>Your booking is confirmed. Please find the attached invoice.<br><br>Thank you for choosing our hotels!";
            var userEmail = request.UserEmail;

            await _emailService.SendInvoiceEmailAsync(userEmail, emailSubject, emailBody, pdfBytes, $"{booking.Id}.pdf");

            return result;
        }
    }
}
