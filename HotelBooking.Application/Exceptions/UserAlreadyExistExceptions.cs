﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.Exceptions
{
    public class UserAlreadyExistException : Exception
    {
        public UserAlreadyExistException(string message) : base(message)
        {
        }
    }
}
