using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HotelBooking.Application.DTOs.City.Responses;
using HotelBooking.Domain.Entities;

namespace HotelBooking.Application.Profiles
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<City, VisitedCitiesDTO>()
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ThumbnailImageUrl, opt => opt.MapFrom(src => src.Images.FirstOrDefault().Url));
            CreateMap<City, CityDTO>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.CountryName))
            .ForMember(dest => dest.PostOffice, opt => opt.MapFrom(src => src.PostOffice))
            .ForMember(dest => dest.NumberOfHotels, opt => opt.MapFrom(src => src.Hotels.Count))  // Example mapping for NumberOfHotels
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
            .ForMember(dest => dest.ModifiedAt, opt => opt.MapFrom(src => src.ModifiedAt.HasValue ? src.ModifiedAt.Value : (DateTime?)null));  // Handle nullable
        }
    }

}
