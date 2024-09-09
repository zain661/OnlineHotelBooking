using HotelBooking.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Infrastructure.Seeding
{
    public class OwnerSeeding
    {
        public static List<Owner> SeedData()
        {
            return new List<Owner>
            {
                new()
                {
                    Id = new Guid("4b72f22b-4a11-44d0-a62d-8a5c5cf3e7a1"),
                    FirstName = "Zaid",
                    LastName = "Ali",
                    Email = "zaid2001@gmail.com",
                    PhoneNumber = "0569451796",
                },
                new()
                {
                    Id = new Guid("9e4bfc5f-65a4-4f92-a5e6-45d7d58b90cb"),
                    FirstName = "Rawan",
                    LastName = "Ibraheem",
                    Email = "rawan2000@gmail.com",
                    PhoneNumber = "05999359292",
                }
            };
        }
    }
}
