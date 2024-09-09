using HotelBooking.Application.Abstractions;
using HotelBooking.Application.Commands.AuthCommands;
using HotelBooking.Application.DTOs.User.Requests;
using HotelBooking.Application.DTOs.User.Responses;
using MediatR;

namespace HotelBooking.Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IMediator _mediator;

        public AuthenticationService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<LoginResponse> LoginAsync(LoginUserDTO loginDto, CancellationToken cancellationToken)
        {
            var command = new LoginCommand(loginDto);
            var response = await _mediator.Send(command, cancellationToken);
            return response;
        }

        public async Task<TokenResponse> RefreshTokenAsync(RefreshTokenDTO refreshTokenDto)
        {
            var command = new RefreshTokenCommand(refreshTokenDto);
            var response = await _mediator.Send(command);
            return response;
        }
    }
}
