using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBooking.Application.DTOs.Review.Responses;
using HotelBooking.Domain.Entities;

namespace HotelBooking.Application.DTOs.Hotel.Responses
{
    public class HotelDetailsDTO
    {
        public String Name {  get; set; }
        public float Rating { get; set; }
        public String Description { get; set; }
        public List<ReviewDTO> Reviews { get; set; }
    }
}
