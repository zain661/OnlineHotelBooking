using System.Linq;
using HotelBooking.Domain.Entities;

namespace HotelBooking.Domain.Interfaces
{
    public interface ICityRepo
    {
        IQueryable<City> GetVisitedCitiesQuery();
        Task<IEnumerable<City>> GetAllCitiesAsync();
        Task<City> GetCityByIdAsync(Guid id);
        Task<City> AddCityAsync(City city);
        Task<City> UpdateCityAsync(City city);
        Task<bool> DeleteCityAsync(Guid id);

    }
}
