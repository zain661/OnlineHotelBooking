using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.DTOs.Booking.Responses
{
    public class CheckoutResult
    {
        public string ConfirmationNumber { get; set; }
        public List<string> HotelAddress { get; set; }
        public List<RoomDetail> RoomDetails { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public double TotalAmount { get; set; }
        public string PaymentStatus { get; set; }
        public string PdfUrl { get; set; }
    }
}
