using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using HotelBooking.Application.Commands.RoomCommands;
using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Interfaces;
using MediatR;

namespace HotelBooking.Application.Handlers.RoomHandlers
{
    public class UpdateRoomCommandHandler : IRequestHandler<UpdateRoomCommand,Guid>
    {
        private readonly IRoomRepo _roomRepository;
        private readonly IValidator<UpdateRoomCommand> _validator;

        public UpdateRoomCommandHandler(IRoomRepo roomRepository, IValidator<UpdateRoomCommand> validator)
        {
            _roomRepository = roomRepository;
            _validator = validator;
        }

        public async Task<Guid> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
            var room = await _roomRepository.GetRoomByIdAsync(request.Id);
            if (room == null)
            {
                throw new Exception($"Room with ID {request.Id} not found.");
            }


            room.RoomTypeId = request.RoomTypeId;
            room.HotelId = request.HotelId;
            room.AdultsCapacity = request.AdultsCapacity;
            room.ChildrenCapacity = request.ChildrenCapacity;
            room.ModifiedAt = DateTime.UtcNow;

            await _roomRepository.UpdateRoomAsync(room);

            return room.Id;
        }
    }

}
