using FluentValidation;
using HotelBooking.Application.DTOs.Hotel.Requests;
using HotelBooking.Application.DTOs.Hotel.Responses;
using HotelBooking.Application.Helpers;
using HotelBooking.Application.Queries.HotelQueries;
using HotelBooking.Application.Services;
using HotelBooking.Application.Abstractions;
using MediatR;
using AutoMapper;
using Microsoft.Extensions.Logging;
using HotelBooking.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Application.Handlers.HotelHandlers
{
    public sealed class GetHotelsSearchQueryHandler : IRequestHandler<GetHotelsSearchQuery, PaginatedList<HotelSearchDTO>>
    {
        private readonly IHotelRepo _repoHotel;
        private readonly IRoomRepo _repoRoom;
        private readonly IMapper _mapper;
        
        private readonly IRoomPriceCalculator _roomPriceCalculator;
        private readonly IValidator<GetHotelsSearchQuery> _validator;
        private readonly ILogger<GetHotelsSearchQueryHandler> _logger;

        public GetHotelsSearchQueryHandler(IHotelRepo hotelRepo, IRoomRepo repoRoom, IMapper mapper,
            IRoomPriceCalculator roomPriceCalculator,
            IValidator<GetHotelsSearchQuery> validator, ILogger<GetHotelsSearchQueryHandler> logger)
        {
            _repoHotel = hotelRepo;
            _repoRoom = repoRoom;
            _mapper = mapper;
            
            _roomPriceCalculator = roomPriceCalculator;
            _validator = validator;
            _logger = logger;
        }

        public async Task<PaginatedList<HotelSearchDTO>> Handle(GetHotelsSearchQuery query, CancellationToken cancellationToken)
        {
            try
            {
                // Validate the query
                var validationResult = await _validator.ValidateAsync(query, cancellationToken);
                if (!validationResult.IsValid)
                {
                    throw new ValidationException(validationResult.Errors);
                }
                _logger.LogInformation("Handling GetHotelsSearchQuery");

                var searchParams = query.HotelSearchParameters;

                _logger.LogDebug("Search parameters: {@SearchParams}", searchParams);

                if (searchParams == null)
                {
                    throw new ArgumentNullException(nameof(searchParams), "Search parameters cannot be null");
                }


                var hotelsQuery = _repoHotel.GetFilteredHotels(searchParams).ToList();

                var roomAvailable = _repoRoom.GetAvailableRooms(searchParams.AdultCapacity, searchParams.ChildrenCapacity, searchParams.CheckIn, searchParams.CheckOut);

                hotelsQuery = hotelsQuery
                   .Where(h => h.Rooms
                       .Where(r => roomAvailable.Contains(r))
                       .Count() >= searchParams.NumberOfRooms).ToList();

                var totalItemCount = hotelsQuery.Count;
                var pageData = new PageData(totalItemCount, searchParams.PageSize, searchParams.PageNumber);

                var paginatedHotels = hotelsQuery
                    .Skip(searchParams.PageSize * (searchParams.PageNumber - 1))
                    .Take(searchParams.PageSize)
                    .ToList();

                var hotels = paginatedHotels.Select(h => 
                {
        //            var PricePerNight = searchParams.Amenities != null && searchParams.Amenities.Any()
        //? h.Rooms
        //    .Select(r => _roomPriceCalculator.CalculatePricePerNight(r, searchParams.Amenities))
        //    .DefaultIfEmpty(0)
        //    .Max()
        //: h.Rooms
        //    .Select(r => r.RoomType.PricePerNight)
        //    .DefaultIfEmpty(0)
        //    .Max();
                    var hotelDto = _mapper.Map<HotelSearchDTO>(h);
                    //hotelDto.PricePerNight = PricePerNight;
                    return hotelDto;
                }).ToList();


                _logger.LogInformation("Successfully retrieved and processed hotels");

                return new PaginatedList<HotelSearchDTO>(hotels, pageData);
            }
            catch (ValidationException ex)
            {
                _logger.LogError(ex, "Validation failed for GetHotelsSearchQuery");
                throw; // Re-throw the exception after logging it
            }
            catch (ArgumentNullException ex)
            {
                _logger.LogError(ex, "Argument null exception occurred");
                throw; // Re-throw the exception after logging it
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while handling GetHotelsSearchQuery");
                throw; // Re-throw the exception after logging it
            }
        }
    }
}
