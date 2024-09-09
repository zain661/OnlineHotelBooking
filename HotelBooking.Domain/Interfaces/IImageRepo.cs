using HotelBooking.Domain.Entities;

namespace HotelBooking.Domain.Interfaces
{
    public interface IImageRepo
    {
        Task<IList<Image>> GetImagesByHotelIdAsync(Guid hotelId);
    }
}
