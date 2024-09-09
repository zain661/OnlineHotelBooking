using AutoMapper;
using HotelBooking.Application.DTOs.Hotel.Responses;
using HotelBooking.Application.DTOs.User.Requests;
using HotelBooking.Domain.Entities;

namespace HotelBooking.Application.Profiles
{
    public class UserProfile: Profile
    {
        public UserProfile() {
            CreateMap<RegisterUserDTO, User>()
            .ForMember(dest => dest.Password, opt => opt.Ignore());

            CreateMap<LoginUserDTO, User>();
        }

    }
}



