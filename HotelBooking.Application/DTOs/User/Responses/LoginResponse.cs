using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.DTOs.User.Responses
{
    public record LoginResponse(bool isLoggedIn, string Message = null!, string Token = null!, string RefreshToken = null!);
}
