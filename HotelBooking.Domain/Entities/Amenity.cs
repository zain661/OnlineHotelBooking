using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Domain.Entities
{
    public class Amenity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; } = 0;
        public IList<RoomType> RoomTypes { get; set; } = new List<RoomType>();
    }
}
