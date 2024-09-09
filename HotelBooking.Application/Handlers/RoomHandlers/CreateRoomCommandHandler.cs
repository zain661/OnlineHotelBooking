using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using HotelBooking.Application.Commands.RoomCommands;
using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Interfaces;
using MediatR;

namespace HotelBooking.Application.Handlers.RoomHandlers
{
    public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, Guid>
    {
        private readonly IRoomRepo _roomRepository;
        private readonly IValidator<CreateRoomCommand> _validator;

        public CreateRoomCommandHandler(IRoomRepo roomRepository, IValidator<CreateRoomCommand> validator)
        {
            _roomRepository = roomRepository;
            _validator = validator;
        }

        public async Task<Guid> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
            var room = new Room
            {
                RoomTypeId = request.RoomTypeId,
                HotelId = request.HotelId,
                AdultsCapacity = request.AdultsCapacity,
                ChildrenCapacity = request.ChildrenCapacity,
                CreatedAt = DateTime.UtcNow,
                ModifiedAt = DateTime.UtcNow
            };

            await _roomRepository.AddRoomAsync(room);
            return room.Id; 
        }
    }
}
