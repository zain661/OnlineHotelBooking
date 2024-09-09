using AutoMapper;
using HotelBooking.Application.DTOs.Hotel.Requests;
using HotelBooking.Application.DTOs.Hotel.Responses;
using HotelBooking.Domain.Entities;
using Microsoft.AspNetCore.Routing.Constraints;


namespace HotelBooking.Application.Profiles
{
    public class HotelProfile : Profile
    {
        public HotelProfile()
        {
            CreateMap<Hotel, FeaturedDealDTO>()
    .ForMember(dest => dest.HotelId, opt => opt.MapFrom(src => src.Id))
    .ForMember(dest => dest.HotelName, opt => opt.MapFrom(src => src.Name))
    .ForMember(dest => dest.ThumbnailImageUrl, opt => opt.MapFrom(src => src.Images[0].Url))
    .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.City.Name))
    .ForMember(dest => dest.StarRating, opt => opt.MapFrom(src => src.Rating))
    // Mapping RoomDeals
    .ForMember(dest => dest.RoomDeals, opt => opt.MapFrom(src => src.Rooms
        .Where(r => r.RoomType.Discounts.Any(d => d.FromDate <= DateTime.Today && d.ToDate >= DateTime.Today))
        .Select(r => new RoomDealDTO
        {
            OriginalPrice = r.RoomType.PricePerNight,
            DiscountedPrices = r.RoomType.Discounts
                .Where(d => d.FromDate <= DateTime.Today && d.ToDate >= DateTime.Today)
                .Select(d => r.RoomType.PricePerNight * (1 - d.DiscountPercentage / 100))
                .ToList()
        }).ToList()));



            CreateMap<Hotel, HotelSearchDTO>();
                    //.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                    //.ForMember(dest => dest.StarRating, opt => opt.MapFrom(src => src.Rating))
                    ////.ForMember(dest => dest.PricePerNight, opt => opt.Ignore())
                    //.ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                    //.ForMember(dest => dest.ThumbnailImage, opt => opt.MapFrom(src => src.Images.FirstOrDefault().Url)); // Assuming you want the first image as thumbnail

            CreateMap<Hotel, CreateHotelDTO>();

            CreateMap<CreateHotelDTO, Hotel>();

            CreateMap<Booking, VisitedHotelsDTO>()
           .ForMember(dest => dest.HotelName, opt => opt.MapFrom(src => src.Rooms.FirstOrDefault().Hotel.Name))
           .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Rooms.FirstOrDefault().Hotel.City.Name))
           .ForMember(dest => dest.ThumbnailImage, opt => opt.MapFrom(src => src.Rooms.FirstOrDefault().Hotel.Images.FirstOrDefault().Url))
           .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => src.Rooms.FirstOrDefault().Hotel.Rating))
           .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => src.Rooms.FirstOrDefault().RoomType.PricePerNight));

            CreateMap<Hotel, HotelDetailsDTO>()
            .ForMember(dest => dest.Reviews, opt => opt.Ignore()) 
            .ForMember(dest => dest.Rating, opt => opt.Ignore());

            CreateMap<Hotel, HotelDTO>()
            .ForMember(dest => dest.StarRate, opt => opt.MapFrom(src => src.Rating));



        }



    }
}
