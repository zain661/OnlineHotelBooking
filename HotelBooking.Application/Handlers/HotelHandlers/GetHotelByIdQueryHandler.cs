using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HotelBooking.Application.DTOs.Hotel.Responses;
using HotelBooking.Application.Queries.HotelQueries;
using HotelBooking.Domain.Interfaces;
using MediatR;

namespace HotelBooking.Application.Handlers.HotelHandlers
{
    public class GetHotelByIdQueryHandler : IRequestHandler<GetHotelByIdQuery, HotelDTO>
    {
        private readonly IHotelRepo _hotelRepository;
        private readonly IMapper _mapper;

        public GetHotelByIdQueryHandler(IHotelRepo hotelRepository, IMapper mapper)
        {
            _hotelRepository = hotelRepository;
            _mapper = mapper;
        }

        public async Task<HotelDTO> Handle(GetHotelByIdQuery request, CancellationToken cancellationToken)
        {
            var hotel = await _hotelRepository.GetHotelByIdAsync(request.Id);
            return _mapper.Map<HotelDTO>(hotel);
        }
    }
}
