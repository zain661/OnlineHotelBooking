﻿using HotelBooking.Domain.Enums;
using System;

namespace HotelBooking.Domain.Entities
{
    public class Payment
    {
        public Guid Id { get; set; }
        public Guid BookingId { get; set; }
        public PaymentMethod Method { get; set; }
        public PaymentStatus Status { get; set; }
        public double Amount { get; set; }

        // Navigation property
        public Booking Booking { get; set; }
    }
}
