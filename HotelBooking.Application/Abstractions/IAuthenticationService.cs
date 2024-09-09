using HotelBooking.Application.Commands;
using HotelBooking.Application.DTOs.User.Requests;
using HotelBooking.Application.DTOs.User.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.Abstractions
{
    public interface IAuthenticationService
    {
        Task<LoginResponse> LoginAsync(LoginUserDTO loginDto, CancellationToken cancellationToken);
        Task<TokenResponse> RefreshTokenAsync(RefreshTokenDTO refreshTokenDto);
    }
}
