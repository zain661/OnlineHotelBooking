using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBooking.Application.DTOs.Hotel.Responses;
using MediatR;

namespace HotelBooking.Application.Queries.UserQueries
{
    public record GetUser_sRecentlyVisitedHotelsQuery(String Email, int Count): IRequest<List<VisitedHotelsDTO>>
    {
    }
}
