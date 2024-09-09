using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using HotelBooking.Application.Commands.CityCommands;
using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Interfaces;
using MediatR;

namespace HotelBooking.Application.Handlers.CityHandlers
{
    public class UpdateCityCommandHandler : IRequestHandler<UpdateCityCommand, Unit>
    {
        private readonly ICityRepo _cityRepository;
        private readonly IValidator<UpdateCityCommand> _validator;

        public UpdateCityCommandHandler(ICityRepo cityRepository, IValidator<UpdateCityCommand> validator)
        {
            _cityRepository = cityRepository;
            _validator = validator;
        }

        public async Task<Unit> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {

                throw new ValidationException(validationResult.Errors);
            }
            var city = await _cityRepository.GetCityByIdAsync(request.Id);

            city.Name = request.Name;
            city.CountryName = request.Country;
            city.PostOffice = request.PostOffice;
            city.ModifiedAt = DateTime.UtcNow;

            await _cityRepository.UpdateCityAsync(city);
            return Unit.Value;
        }
    }
}
