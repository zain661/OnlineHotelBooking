using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBooking.Application.DTOs.Room.Responses;
using MediatR;

namespace HotelBooking.Application.Queries.RoomQueries
{
    public class GetRoomByIdQuery : IRequest<RoomDTO>
    {
        public Guid Id { get; set; }
    }

}
