using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.DTOs.Hotel.Responses
{
    public class HotelDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float StarRate { get; set; }
        public Guid OwnerId { get; set; }
        public int NumberOfRooms { get; set; }
        public Guid CityId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }

}
