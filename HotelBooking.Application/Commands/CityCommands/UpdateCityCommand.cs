using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace HotelBooking.Application.Commands.CityCommands
{
    public class UpdateCityCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string PostOffice { get; set; }
    }

}
