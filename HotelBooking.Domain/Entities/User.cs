using HotelBooking.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Domain.Entities
{
    public class User: Human
    {
        public string? Password { get; set; }
        public UserRole Role { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
        public IList<Booking>? Bookings {  get; set; }
    }
}
