using HotelBooking.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Domain.Entities
{
    public class Image
    {
        public Guid Id { get; set; }
        public string Url { get; set; }
        public ImageType Type { get; set; }
        public ImageFormat Format { get; set; }
        // Foreign Key to Hotel
        public Guid? HotelId { get; set; }

        // Navigation Property to Hotel
        public Hotel Hotel { get; set; }
        public Guid? CityId { get; set; }
        public City City { get; set; }
        // To indicate whether the image is for a hotel or a city
        public ImageOwnerType OwnerType { get; set; }
    }
}
