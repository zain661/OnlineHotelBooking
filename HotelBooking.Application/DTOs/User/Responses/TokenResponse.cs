using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.DTOs.User.Responses
{
    public class TokenResponse
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public string Message { get; set; }

        public TokenResponse(string token, string refreshToken, string message = null, bool success = true)
        {
            Token = token;
            RefreshToken = refreshToken;
            Message = message;
        }
    }

}
