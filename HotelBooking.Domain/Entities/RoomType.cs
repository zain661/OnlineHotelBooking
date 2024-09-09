using HotelBooking.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Domain.Entities
{
    public class RoomType
    {
        public Guid RoomTypeId { get; set; }
        public RoomCategory Category { get; set; }
        public float PricePerNight { get; set; }
        public IList<Amenity> Amenities { get; set; }
        // Navigation property to hold multiple discounts
        public ICollection<Discount> Discounts { get; set; }
        public ICollection<Room> Rooms { get; set; } = new List<Room>();

    }
}
