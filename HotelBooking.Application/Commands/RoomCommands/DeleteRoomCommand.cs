using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace HotelBooking.Application.Commands.RoomCommands
{
    public class DeleteRoomCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }

}
