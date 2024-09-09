﻿using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;
namespace HotelBooking.Domain.Entities
{
    public class Room
    {
        public Guid Id { get; set; }
        
        public Guid? RoomTypeId { get; set; }
        public RoomType? RoomType { get; set; }
        public int AdultsCapacity { get; set; }
        public int ChildrenCapacity { get; set; }
        public float Rating { get; set; }
        public Guid HotelId { get; set; }
        public Hotel Hotel { get; set; }

        public IList<Booking> Bookings { get; set; } = new List<Booking>();
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; } // Nullable because it might not be modified yet
    }
}
