using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBooking.Application.DTOs.Hotel.Responses;
using MediatR;

namespace HotelBooking.Application.Queries.HotelQueries
{
    public class GetHotelsQuery : IRequest<List<HotelDTO>>
    {
        
    }

}
