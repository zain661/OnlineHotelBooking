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
    public class GetRoomByIdQueryHandler : IRequestHandler<GetRoomByIdQuery, RoomDTO>
    {
        private readonly IRoomRepo _roomRepository;
        private readonly IMapper _mapper;

        public GetRoomByIdQueryHandler(IRoomRepo roomRepository, IMapper mapper)
        {
            _roomRepository = roomRepository;
            _mapper = mapper;
        }

        public async Task<RoomDTO> Handle(GetRoomByIdQuery request, CancellationToken cancellationToken)
        {
            var room = await _roomRepository.GetRoomByIdAsync(request.Id);
            return _mapper.Map<RoomDTO>(room);
        }
    }

}
