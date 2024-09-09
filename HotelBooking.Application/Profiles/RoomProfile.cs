using AutoMapper;
using HotelBooking.Application.DTOs.Room.Responses;
using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Enums;

namespace HotelBooking.Application.Profiles
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<Room, AvailableRoomsDTO>()
                .ForMember(dest => dest.PricePerNight, opt => opt.MapFrom(src => src.RoomType != null ? src.RoomType.PricePerNight : 0))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.RoomType != null ? src.RoomType.Category : default(RoomCategory)))
                .ForMember(dest => dest.AdultsCapacity, opt => opt.MapFrom(src => src.AdultsCapacity))
                .ForMember(dest => dest.ChildrenCapacity, opt => opt.MapFrom(src => src.ChildrenCapacity))
                .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => src.Rating));
            CreateMap<Room, RoomDTO>();
        }
    }
}
