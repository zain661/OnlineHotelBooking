using HotelBooking.Domain.Entities;
using System;

namespace HotelBooking.Application.DTOs.Hotel.Responses
{
    public class FeaturedDealDTO
    {
        public Guid HotelId { get; set; }
        public string HotelName { get; set; }
        public string ThumbnailImageUrl { get; set; }
        public string Location { get; set; }
        public int StarRating { get; set; }
        public List<RoomDealDTO> RoomDeals { get; set; } // This holds the deals for all rooms with active discounts
    }


    public class RoomDealDTO
    {
        public string RoomType { get; set; }
        public float OriginalPrice { get; set; }
        public List<float> DiscountedPrices { get; set; } // List of discounted prices for this room type
    }


}
