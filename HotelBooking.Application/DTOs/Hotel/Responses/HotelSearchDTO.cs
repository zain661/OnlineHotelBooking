using HotelBooking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.DTOs.Hotel.Responses
{
    public class HotelSearchDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        //public float Rating { get; set; }
        ////public float PricePerNight { get; set; }
        //public string Description { get; set; }
        //public String ThumbnailImage { get; set; }
    }
}
