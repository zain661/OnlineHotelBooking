﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Domain.Entities
{
    public class Owner: Human
    {
        public List<Hotel> Hotels { get; set; }
    }
}
