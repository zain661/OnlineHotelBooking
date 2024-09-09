using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HotelBooking.Application.DTOs.City.Responses; // Ensure this namespace is correct
using HotelBooking.Application.Queries.CityQueries;
using HotelBooking.Domain.Interfaces;
using MediatR;

namespace HotelBooking.Application.Handlers.CityHandlers
{
    public class GetCitiesQueryHandler : IRequestHandler<GetCitiesQuery, List<CityDTO>>
    {
        private readonly ICityRepo _cityRepository;
        private readonly IMapper _mapper;

        public GetCitiesQueryHandler(ICityRepo cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public async Task<List<CityDTO>> Handle(GetCitiesQuery request, CancellationToken cancellationToken)
        {
            var cities = await _cityRepository.GetAllCitiesAsync();
            return _mapper.Map<List<CityDTO>>(cities);
        }
    }
}
