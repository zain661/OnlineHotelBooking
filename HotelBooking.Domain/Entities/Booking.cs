using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Domain.Entities
{
    public class Booking
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public DateTime BookingDate { get; set; }
        public double TotalAmount { get; set; }
        public List<Room> Rooms { get; set; } = new List<Room>();
        public Review? Review { get; set; }
        public Payment? Payment { get; set; }
    }
}
