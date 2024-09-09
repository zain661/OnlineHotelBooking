using AutoMapper;
using HotelBooking.Application.DTOs.Review.Responses;
using HotelBooking.Domain.Entities;

namespace HotelBooking.Application.Profiles
{
    public class ReviewProfile: Profile
    {
        public ReviewProfile() {
            CreateMap<Review, ReviewDTO>();
        }

    }
}
