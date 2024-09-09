using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HotelBooking.Application.DTOs.Room.Responses;
using HotelBooking.Application.Queries.RoomQueries;
using HotelBooking.Domain.Interfaces;
using MediatR;

namespace HotelBooking.Application.Handlers.RoomHandlers
{
    public class GetRoomsQueryHandler : IRequestHandler<GetRoomsQuery, List<RoomDTO>>
    {
        private readonly IRoomRepo _roomRepository;
        private readonly IMapper _mapper;

        public GetRoomsQueryHandler(IRoomRepo roomRepository, IMapper mapper)
        {
            _roomRepository = roomRepository;
            _mapper = mapper;
        }

        public async Task<List<RoomDTO>> Handle(GetRoomsQuery request, CancellationToken cancellationToken)
        {
            var rooms = await _roomRepository.GetAllRoomsAsync();
            return _mapper.Map<List<RoomDTO>>(rooms);
        }
    }

}
