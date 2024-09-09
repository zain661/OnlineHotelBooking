using AutoMapper;
using HotelBooking.Application.DTOs.Image.Responses;
using HotelBooking.Domain.Entities;

namespace HotelBooking.Application.MappingProfiles
{
    public class ImageProfile : Profile
    {
        public ImageProfile()
        {
            CreateMap<Image, ImageDTO>();
        }
    }
}
