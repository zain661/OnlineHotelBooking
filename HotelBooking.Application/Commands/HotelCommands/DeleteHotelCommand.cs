using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace HotelBooking.Application.Commands.HotelCommands
{
    public class DeleteHotelCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }

}
