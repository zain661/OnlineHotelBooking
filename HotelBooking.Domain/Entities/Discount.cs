using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Domain.Entities
{
    public class Discount
    {
        public Guid Id { get; set; }
        public Guid RoomTypeId { get; set; }  // Foreign Key
        public RoomType RoomType { get; set; }  // Navigation Property
        public float DiscountPercentage { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }

}
