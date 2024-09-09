using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBooking.Domain.Enums;

namespace HotelBooking.Application.DTOs.Room.Requests
{
    public class RoomSearchParameters
    {
        public int? AdultCapacity { get; set; } = 2;
        public int? ChildrenCapacity { get; set; } = 0;
        public DateTime? CheckIn { get; set; } = DateTime.Today;
        public DateTime? CheckOut { get; set; } = DateTime.Today.AddDays(1);
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        private List<string>? _amenities = new List<string>();
        public List<string>? Amenities
        {
            get => _amenities;
            set => _amenities = value?.Select(a => a.Trim().ToLower()).ToList();
        }
        public float? MinPrice { get; set; } = null;
        public float? MaxPrice { get; set; } = null;
        //public RoomCategory? RoomCategory { get; set; }
    }
}
