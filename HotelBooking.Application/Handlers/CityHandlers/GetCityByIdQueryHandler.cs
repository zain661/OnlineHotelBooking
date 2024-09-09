using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HotelBooking.Application.DTOs.City.Responses;
using HotelBooking.Application.Queries.CityQueries;
using HotelBooking.Domain.Interfaces;
using MediatR;

namespace HotelBooking.Application.Handlers.CityHandlers
{
    public class GetCityByIdQueryHandler : IRequestHandler<GetCityByIdQuery, CityDTO>
    {
        private readonly ICityRepo _cityRepository;
        private readonly IMapper _mapper;

        public GetCityByIdQueryHandler(ICityRepo cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public async Task<CityDTO> Handle(GetCityByIdQuery request, CancellationToken cancellationToken)
        {
            var city = await _cityRepository.GetCityByIdAsync(request.Id);
            return _mapper.Map<CityDTO>(city);
        }
    }

}
