using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using HotelBooking.Application.Commands.HotelCommands;
using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Interfaces;
using MediatR;

namespace HotelBooking.Application.Handlers.HotelHandlers
{
    public class UpdateHotelCommandHandler : IRequestHandler<UpdateHotelCommand, Unit>
    {
        private readonly IHotelRepo _hotelRepository;
        private readonly IValidator<UpdateHotelCommand> _validator;

        public UpdateHotelCommandHandler(IHotelRepo hotelRepository, IValidator<UpdateHotelCommand> validator)
        {
            _hotelRepository = hotelRepository;
            _validator = validator;
        }

        public async Task<Unit> Handle(UpdateHotelCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
            var hotel = await _hotelRepository.GetHotelByIdAsync(request.Id);

            hotel.Name = request.Name;
            hotel.Rating = request.StarRate;
            hotel.OwnerId = request.Owner;
            hotel.CityId = request.CityId;
            hotel.ModifiedAt = DateTime.UtcNow;

            await _hotelRepository.UpdateHotelAsync(hotel);
            return Unit.Value;
        }
    }

}
