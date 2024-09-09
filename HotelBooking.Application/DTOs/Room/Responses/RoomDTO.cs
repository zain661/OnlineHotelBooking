using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Enums;

namespace HotelBooking.Application.DTOs.Room.Responses
{
    public class RoomDTO
    {
        public Guid Id { get; set; }
        public Guid RoomTypeId { get; set; }
        public int AdultsCapacity { get; set; }
        public int ChildrenCapacity { get; set; }
        public Guid HotelId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; } // Nullable because it might not be modified yet
    }

}
