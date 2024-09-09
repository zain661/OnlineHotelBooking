using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using HotelBooking.Application.Commands.CityCommands;
using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Interfaces;
using MediatR;

namespace HotelBooking.Application.Handlers.CityHandlers
{
    public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand, Guid>
    {
        private readonly ICityRepo _cityRepository;
        private readonly IValidator<CreateCityCommand> _validator;

        public CreateCityCommandHandler(ICityRepo cityRepository, IValidator<CreateCityCommand> validator)
        {
            _cityRepository = cityRepository;
            _validator = validator;
        }

        public async Task<Guid> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                
                return Guid.Empty; 
            }

            var city = new City
            {
                Name = request.Name,
                CountryName = request.Country,
                PostOffice = request.PostOffice,
                CreatedAt = DateTime.UtcNow,
                ModifiedAt = DateTime.UtcNow
            };

            await _cityRepository.AddCityAsync(city);
            return city.Id;
        }
    }

}
