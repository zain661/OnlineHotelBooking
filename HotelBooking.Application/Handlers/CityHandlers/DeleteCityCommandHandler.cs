using System;
using System.Threading;
using System.Threading.Tasks;
using HotelBooking.Application.Commands.CityCommands;
using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Interfaces;
using MediatR;

namespace HotelBooking.Application.Handlers.CityHandlers
{
    public class DeleteCityCommandHandler : IRequestHandler<DeleteCityCommand, Unit>
    {
        private readonly ICityRepo _cityRepository;

        public DeleteCityCommandHandler(ICityRepo cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<Unit> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
        {

            await _cityRepository.DeleteCityAsync(request.Id);
            return Unit.Value;
        }
    }
}
