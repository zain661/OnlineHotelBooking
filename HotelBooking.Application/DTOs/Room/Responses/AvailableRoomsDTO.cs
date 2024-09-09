using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBooking.Domain.Enums;

namespace HotelBooking.Application.DTOs.Room.Responses
{
    public class AvailableRoomsDTO
    {
        public float PricePerNight { get; set; }
        public int AdultsCapacity { get; set; }
        public int ChildrenCapacity { get; set; }
        public float Rating { get; set; }
        public RoomCategory Category { get; set; }
    }
}
