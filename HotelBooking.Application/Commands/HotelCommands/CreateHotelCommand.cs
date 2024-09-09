using HotelBooking.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;

namespace HotelBooking.Application.Commands.HotelCommands
{
    public class CreateHotelCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public int Rating { get; set; }
        public string StreetAddress { get; set; }
        public string Description { get; set; }
        public int NumberOfRooms { get; set; }
        public Guid CityId { get; set; }
        public Guid OwnerId { get; set; }
        public string PhoneNumber { get; set; }
        public HotelCategory Category { get; set; }
    }
}
