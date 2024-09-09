using HotelBooking.Domain.Entities;
using HotelBooking.Domain.Enums;


namespace Infrastructure.Seeding
{
    public class UserSeeding
    {
        public static IEnumerable<User> SeedData()
        {
            return new List<User>
            {
                new User
                {
                    Id = new Guid("af838868-a3e8-47d0-b1a3-8111396dda35"),
                    FirstName = "Zain",
                    LastName = "Assaf",
                    Email = "zaynassaf2001@gmail.com",
                    PhoneNumber = "123-456-7890",
                    Password = "hashedpassword1", // Replace with a real hashed password
                    Role = UserRole.Admin // Assuming you have a UserRole enum
                },
                new User
                {
                    Id = new Guid("b748f5b2-6b48-4e5d-9e4b-c5bfa54cb1f2"),
                    FirstName = "Leen",
                    LastName = "Hammad",
                    Email = "leenhammad@example.com",
                    PhoneNumber = "987-654-3210",
                    Password = "hashedpassword2", // Replace with a real hashed password
                    Role = UserRole.RegularUser // Assuming you have a UserRole enum
                }
            };
        }
    }
}
