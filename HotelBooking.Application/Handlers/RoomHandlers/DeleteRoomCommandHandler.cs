using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBooking.Application.Commands.RoomCommands;
using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Interfaces;
using MediatR;

namespace HotelBooking.Application.Handlers.RoomHandlers
{
    public class DeleteRoomCommandHandler : IRequestHandler<DeleteRoomCommand, Unit>
    {
        private readonly IRoomRepo _roomRepository;

        public DeleteRoomCommandHandler(IRoomRepo roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<Unit> Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
        {
           
            await _roomRepository.DeleteRoomAsync(request.Id);
            return Unit.Value;
        }
    }

}
