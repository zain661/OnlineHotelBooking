using AutoMapper;
using FluentValidation;
using HotelBooking.Application.Commands.HotelCommands;
using HotelBooking.Application.DTOs.Hotel.Responses;
using HotelBooking.Application.Queries.HotelQueries;
using HotelBooking.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBooking.Application.Handlers.HotelHandlers
{
    public sealed class GetFeaturedDealsQueryHandler : IRequestHandler<GetFeaturedDealsQuery, List<FeaturedDealDTO>>
    {
        private readonly IHotelRepo _hotelRepo;
        private readonly IMapper _mapper;
        private readonly IValidator<GetFeaturedDealsQuery> _validator;

        public GetFeaturedDealsQueryHandler(IHotelRepo hotelRepo, IMapper mapper, IValidator<GetFeaturedDealsQuery> validator)
        {
            _hotelRepo = hotelRepo;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<List<FeaturedDealDTO>> Handle(GetFeaturedDealsQuery request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
            // Retrieve hotels with rooms and room types including discounts
            var hotelsWithActiveDiscounts = await _hotelRepo.GetHotelsWithActiveDiscountsQuery()
                .ToListAsync(cancellationToken);

            // Process and calculate featured deals
            var featuredDeals = hotelsWithActiveDiscounts
     .SelectMany(h => h.Rooms
         .Select(r => new
         {
             Hotel = r.Hotel,
             RoomType = r.RoomType,
             PricePerNight = r.RoomType.PricePerNight,
             DiscountedPrices = r.RoomType.Discounts
                 .Where(d => d.FromDate <= DateTime.Today && d.ToDate >= DateTime.Today)
                 .Select(d => r.RoomType.PricePerNight * (1 - d.DiscountPercentage / 100))
                 .ToList()
         })
     )
     .Where(x => x.DiscountedPrices.Any())
     .GroupBy(x => x.Hotel)
     .Select(g =>
     {
         var hotel = g.Key;
         if (hotel == null) return null;

         // Map the hotel information
         var dealDto = _mapper.Map<FeaturedDealDTO>(hotel);
         if (dealDto == null) return null;

         // Add all rooms with their original and discounted prices to the DTO
         dealDto.RoomDeals = g.Select(room => new RoomDealDTO
         {
             OriginalPrice = room.PricePerNight,
             DiscountedPrices = room.DiscountedPrices
         }).ToList();

         return dealDto;
     })
     .Where(d => d != null)
     .OrderByDescending(d => d.RoomDeals.SelectMany(rd => rd.DiscountedPrices).Min())
     .Take(request.Count)
     .ToList();
            return featuredDeals;
        }
    }
}
