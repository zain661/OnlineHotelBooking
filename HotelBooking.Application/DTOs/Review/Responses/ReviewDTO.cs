using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.DTOs.Review.Responses
{
    public class ReviewDTO
    {
        public string Comment { get; set; }
        public DateTime ReviewDate { get; set; }
        public float Rating { get; set; }
    }
}
