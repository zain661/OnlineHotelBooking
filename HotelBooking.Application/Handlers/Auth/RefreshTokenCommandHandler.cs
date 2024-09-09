using HotelBooking.Application.Abstractions;
using HotelBooking.Application.Commands.AuthCommands;
using HotelBooking.Application.DTOs.User.Responses;
using HotelBooking.Domain.Interfaces;
using MediatR;
using System.Security.Claims;


namespace HotelBooking.Application.Handlers.Auth
{
    public sealed class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, TokenResponse>
    {
        private readonly IUserRepo _userRepo;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public RefreshTokenCommandHandler(IUserRepo userRepo, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepo = userRepo;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<TokenResponse> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var principal = _jwtTokenGenerator.GetPrincipalFromExpiredToken(request.refreshTokenDTO.Token);
            if (principal == null)
            {
                return new TokenResponse(null, null, "Invalid token");
            }

            var email = principal.FindFirstValue(ClaimTypes.Email);
            if (email == null)
            {
                return new TokenResponse(null, null, "Invalid token");
            }

            var user = await _userRepo.GetUserByEmailAsync(email);
            if (user == null)
            {
                return new TokenResponse(null, null, "User not found");
            }

            var savedRefreshToken = await _userRepo.GetRefreshTokenAsync(user.Id);
            if (savedRefreshToken != request.refreshTokenDTO.RefreshToken)
            {
                return new TokenResponse(null, null, "Invalid refresh token");
            }

            var newJwtToken = _jwtTokenGenerator.GenerateToken(user);
            var newRefreshToken = _jwtTokenGenerator.GenerateRefreshToken();

            await _userRepo.SaveRefreshTokenAsync(user.Id, newRefreshToken, DateTime.UtcNow.AddHours(1));

            return new TokenResponse(newJwtToken, newRefreshToken);
        }
    }
}
