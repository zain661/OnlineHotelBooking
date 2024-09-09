using HotelBooking.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Domain.Entities
{
    public class Hotel
    {
        public Guid Id { get; set; }
        public Guid CityId { get; set; }
        public Guid OwnerId { get; set; }
        public string Name { get; set; }
        public float Rating { get; set; }
        public string StreetAddress { get; set; }
        public string Description { get; set; }
        public int NumberOfRooms { get; set; }

        // Navigation property to City
        
        public City City { get; set; }

        // Navigation property to Owner
        
        public Owner Owner { get; set; }

        
        public List<Image> Images { get; set; }
        public string PhoneNumber { get; set; }
        
        
        public HotelCategory Category { get; set; }
        public List<Room> Rooms { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; } // Nullable because it might not be modified yet
    }
}
