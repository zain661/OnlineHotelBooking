using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBooking.Application.Commands.HotelCommands;
using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Interfaces;
using MediatR;

namespace HotelBooking.Application.Handlers.HotelHandlers
{
    public class DeleteHotelCommandHandler : IRequestHandler<DeleteHotelCommand, Unit>
    {
        private readonly IHotelRepo _hotelRepository;

        public DeleteHotelCommandHandler(IHotelRepo hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public async Task<Unit> Handle(DeleteHotelCommand request, CancellationToken cancellationToken)
        {
            await _hotelRepository.DeleteHotelByIdAsync(request.Id);
            return Unit.Value;
        }
    }

}
