using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace HotelBooking.Application.Commands.HotelCommands
{
    public class UpdateHotelCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int StarRate { get; set; }
        public Guid Owner { get; set; }
        public Guid CityId { get; set; }
    }

}
