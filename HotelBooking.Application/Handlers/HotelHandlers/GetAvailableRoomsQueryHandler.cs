using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HotelBooking.Application.DTOs.Room.Responses;
using HotelBooking.Application.Helpers;
using HotelBooking.Application.Queries.RoomQueries;
using HotelBooking.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Application.Handlers.HotelHandlers
{
    public class GetAvailableRoomsQueryHandler : IRequestHandler<GetAvailableRoomsQuery, PaginatedList<AvailableRoomsDTO>>
    {
        private readonly IRoomRepo _repoRoom;
        private readonly IMapper _mapper;

        public GetAvailableRoomsQueryHandler(IRoomRepo repoRoom, IMapper mapper)
        {
            _repoRoom = repoRoom;
            _mapper = mapper;
        }

        public async Task<PaginatedList<AvailableRoomsDTO>> Handle(GetAvailableRoomsQuery query, CancellationToken cancellationToken)
        {

            // Step 1: Start with available rooms query
            var roomsQuery = _repoRoom.GetAvailableRoomsByHotel(
                query.HotelId,
                query.roomSearchParameters.AdultCapacity,
                query.roomSearchParameters.ChildrenCapacity,
                query.roomSearchParameters.CheckIn,
                query.roomSearchParameters.CheckOut);

            // Step 2: Filter by price if provided
            if (query.roomSearchParameters.MinPrice.HasValue || query.roomSearchParameters.MaxPrice.HasValue)
            {
                roomsQuery = _repoRoom.FilterRoomsByPrice(roomsQuery,
                    query.roomSearchParameters.MinPrice,
                    query.roomSearchParameters.MaxPrice);
            }

            // Step 3: Filter by amenities if provided
            if (query.roomSearchParameters.Amenities != null && query.roomSearchParameters.Amenities.Any())
            {
                roomsQuery = _repoRoom.FilterRoomsByAmenities(roomsQuery,
                    query.roomSearchParameters.Amenities);
            }

            // Step 4: Get the total count of filtered rooms
            var totalRoomCount = await roomsQuery.CountAsync(cancellationToken);
            // Step 5: Apply pagination
            var paginatedRooms = await roomsQuery
                .Skip((query.roomSearchParameters.PageNumber - 1) * query.roomSearchParameters.PageSize)
                .Take(query.roomSearchParameters.PageSize)
                .ToListAsync(cancellationToken);
            var selectedAmenities = query.roomSearchParameters.Amenities ?? Enumerable.Empty<string>();
            // Calculate the price per night for each room and map to RoomDTO
            var roomDtos = paginatedRooms.Select(room =>
            {
                var pricePerNight = _repoRoom.CalculatePricePerNight(room, selectedAmenities);
                var roomDto = _mapper.Map<AvailableRoomsDTO>(room);
                roomDto.PricePerNight = pricePerNight;
                return roomDto;
            }).ToList();

            // Create a PaginatedList of RoomDTOs
            var pageData = new PageData(totalRoomCount, query.roomSearchParameters.PageSize, query.roomSearchParameters.PageNumber);
            return new PaginatedList<AvailableRoomsDTO>(roomDtos, pageData);
        }
    }
}
