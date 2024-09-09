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
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Application.Handlers.HotelHandlers
{
    public class GetHotelsQueryHandler : IRequestHandler<GetHotelsQuery, List<HotelDTO>>
    {
        private readonly IHotelRepo _hotelRepository;
        private readonly IMapper _mapper;

        public GetHotelsQueryHandler(IHotelRepo hotelRepository, IMapper mapper)
        {
            _hotelRepository = hotelRepository;
            _mapper = mapper;
        }

        public async Task<List<HotelDTO>> Handle(GetHotelsQuery request, CancellationToken cancellationToken)
        {
            var hotels = await _hotelRepository.GetAllHotels().ToListAsync();
            return _mapper.Map<List<HotelDTO>>(hotels);
        }

    }
}
