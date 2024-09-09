using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBooking.Application.DTOs.City.Responses;
using MediatR;

namespace HotelBooking.Application.Queries.CityQueries
{
    public class GetCityByIdQuery : IRequest<CityDTO>
    {
        public Guid Id { get; set; }
    }

}
