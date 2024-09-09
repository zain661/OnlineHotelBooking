using Microsoft.EntityFrameworkCore;
using AutoMapper;
using HotelBooking.Application.Queries.CityQueries;
using HotelBooking.Domain.Interfaces;
using MediatR;
using HotelBooking.Application.DTOs.City.Responses;

namespace HotelBooking.Application.Handlers.CityHandlers
{
    public sealed class TopVisitedCitiesQueryHandler : IRequestHandler<GetTopVisitedCitiesQuery, List<VisitedCitiesDTO>>
    {
        private readonly ICityRepo _cityRepo;
        private readonly IMapper _mapper;

        public TopVisitedCitiesQueryHandler(ICityRepo cityRepo, IMapper mapper)
        {
            _cityRepo = cityRepo;
            _mapper = mapper;
        }
        public async Task<List<VisitedCitiesDTO>> Handle(GetTopVisitedCitiesQuery request, CancellationToken cancellationToken)
        {
            var citiesQuery = _cityRepo.GetVisitedCitiesQuery();

            var topCities = await citiesQuery
    .GroupBy(c => c)
    .OrderByDescending(g => g.Count())
    .Take(5)
    .Select(g => g.Key)
    .ToListAsync();

            return _mapper.Map<List<VisitedCitiesDTO>>(topCities);

        }
    }
}
