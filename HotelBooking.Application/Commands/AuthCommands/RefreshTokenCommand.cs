using HotelBooking.Application.DTOs.User.Requests;
using HotelBooking.Application.DTOs.User.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.Commands.AuthCommands
{
    public record RefreshTokenCommand(RefreshTokenDTO refreshTokenDTO) : IRequest<TokenResponse>
    {
    }
}
