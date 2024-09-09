using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace HotelBooking.Application.Commands.RoomCommands
{
    public class CreateRoomCommand : IRequest<Guid>
    {
        public Guid RoomTypeId { get; set; }
        public Guid HotelId { get; set; }
        public int AdultsCapacity { get; set; }
        public int ChildrenCapacity { get; set; }
    }

}
