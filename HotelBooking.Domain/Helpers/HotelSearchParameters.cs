using HotelBooking.Domain.Enums;

namespace HotelBooking.Domain.Helpers
{
    public class HotelSearchParameters
    {
        private String _city { get; set; } = String.Empty;
        public string City
        {
            get => _city;
            set => _city = value?.Trim().ToLower() ?? string.Empty;
        }
        public int? AdultCapacity { get; set; } = 2;
        public int? ChildrenCapacity { get; set; } = 0;
        public int? NumberOfRooms { get; set; } = 1;
        public DateTime? CheckIn { get; set; } = DateTime.Today;
        public DateTime? CheckOut { get; set; } = DateTime.Today.AddDays(1);
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public HotelCategory? Category { get; set; } = null;
        public float? Rating { get; set; } = null;
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
