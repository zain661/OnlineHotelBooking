using HotelBooking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.Abstractions
{
    public interface IRoomPriceCalculator
    {
        float CalculatePricePerNight(Room room, IEnumerable<string> amenities);
    }
}