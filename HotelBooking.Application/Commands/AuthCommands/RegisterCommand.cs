using HotelBooking.Application.DTOs.User.Requests;
using HotelBooking.Application.DTOs.User.Responses;
using MediatR;

namespace HotelBooking.Application.Commands.AuthCommands
{
    public record RegisterCommand(RegisterUserDTO registerUserDto) : IRequest<RegistrationResponse>;

}
