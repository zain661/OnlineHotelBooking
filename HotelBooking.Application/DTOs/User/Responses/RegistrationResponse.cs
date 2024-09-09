using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.DTOs.User.Responses
{
    public record RegistrationResponse(bool isRegistered, string Message = null!);
}
