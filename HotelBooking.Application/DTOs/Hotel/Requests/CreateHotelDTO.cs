using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.DTOs.Hotel.Requests
{
    public record CreateHotelDTO
    {
        public Guid CityId { get; set; }
        public Guid OwnerId { get; set; }
        public string Name { get; set; }
        public float Rating { get; set; }
        public int NumberOfRooms { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public string StreetAddress { get; set; }
    }

}
