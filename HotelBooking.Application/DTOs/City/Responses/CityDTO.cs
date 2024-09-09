using System;

namespace HotelBooking.Application.DTOs.City.Responses
{
    public class CityDTO
    {
        public Guid Id { get; set; }  // Change to Guid
        public string Name { get; set; }
        public string Country { get; set; }
        public string PostOffice { get; set; }
        public int NumberOfHotels { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }  // Nullable to match domain model
    }
}
