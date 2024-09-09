using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Domain.Entities
{
    public class City
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CountryName { get; set; }
        public string PostOffice { get; set; }
        public List<Hotel> Hotels { get; set; }
        public List<Image> Images { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; } // Nullable because it might not be modified yet

    }
}
