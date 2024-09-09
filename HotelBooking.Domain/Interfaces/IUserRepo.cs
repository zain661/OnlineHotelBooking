using HotelBooking.Domain.Entities;
namespace HotelBooking.Domain.Interfaces
{
    public interface IUserRepo
    {
        Task<User> AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(User user);
        Task<User?> GetUserByEmailAsync(string email);
        Task SaveRefreshTokenAsync(Guid userId, string refreshToken, DateTime expiryTime);
        Task<string> GetRefreshTokenAsync(Guid userId);
        Task RemoveRefreshTokenAsync(Guid userId);

    }
}
