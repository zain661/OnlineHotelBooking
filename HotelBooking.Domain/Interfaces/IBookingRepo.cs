using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBooking.Domain.Entities;

namespace HotelBooking.Domain.Interfaces
{
    public interface IBookingRepo
    {
        IQueryable<Booking> GetLastUserBookingsAsync(Guid userId);
        Task AddAsync(Booking booking);
    }
}
