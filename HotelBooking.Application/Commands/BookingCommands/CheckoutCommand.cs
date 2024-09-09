using System;
using HotelBooking.Application.DTOs.Booking.Responses;
using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Enums;
using MediatR;

namespace HotelBooking.Application.Commands.BookingCommands
{
    public class CheckoutCommand : IRequest<CheckoutResult>
    {
        public Guid UserId { get; set; }
        public String UserName { get; set; }
        public string UserEmail { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        //public List<Guid> RoomIds { get; set; }
        public List<RoomSelection> RoomSelections { get; set; } = new List<RoomSelection>(); 
        public PaymentMethod PaymentMethod { get; set; }
        public double TotalAmount { get; set; }
    }
    public class RoomSelection
    {
        public Guid RoomId { get; set; }
        public double PricePerNight { get; set; }  // The price per night already calculated including amenities
    }
}
