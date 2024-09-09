namespace HotelBooking.Application.DTOs.City.Requests
{
    public class CreateCityDTO
    {
        public string Name { get; set; } = string.Empty;
        public string CountryName { get; set; } = string.Empty;
        public string PostOffice { get; set; } = string.Empty;
    }
}
