using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.DTOs.Hotel.Responses
{
    public class VisitedHotelsDTO
    {
        //public Guid Id { get; set; }
        public string HotelName { get; set; }
        public String City { get; set; }
        public String ThumbnailImage { get; set; }
        public float Rating { get; set; }
        public float TotalAmount { get; set; }
        //public string Owner { get; set; }
        //public string CityName { get; set; }
        //public DateTime CreatedAt { get; set; }
        //public DateTime ModifiedAt { get; set; }
    }

}
