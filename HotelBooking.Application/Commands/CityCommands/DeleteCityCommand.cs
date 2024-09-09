using System;
using MediatR;

namespace HotelBooking.Application.Commands.CityCommands
{
    public class DeleteCityCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
