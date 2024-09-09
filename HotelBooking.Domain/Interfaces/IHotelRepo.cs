using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Helpers;


namespace HotelBooking.Domain.Interfaces
{
    public interface IHotelRepo
    {
        IQueryable<Hotel> GetAllHotels();
        IQueryable<Hotel> GetHotelsWithActiveDiscountsQuery();
        IQueryable<Hotel> GetFilteredHotels(HotelSearchParameters searchParams);
        Task<Hotel> GetHotelByIdAsync(Guid id);
        Task<Hotel> GetHotelByNameAsync(string name);
        Task<Hotel> CreateHotelAsync(Hotel hotel);
        Task<Hotel> UpdateHotelAsync(Hotel hotel);
        Task<Hotel> DeleteHotelByIdAsync(Guid id);

    }
}
