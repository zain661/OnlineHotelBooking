using System.ComponentModel.DataAnnotations;
using HotelBooking.Domain.Enums;
namespace HotelBooking.Application.DTOs.User.Requests
{
    public class RegisterUserDTO
    {
        [Required]
        public string? FirstName { get; set; } = string.Empty;
        [Required]
        public string? LastName { get; set; } = string.Empty;
        [Required, EmailAddress] //Ensures that the Email field contains a valid email address.
        public string? Email { get; set; } = string.Empty;
        [Required]
        public string? Password { get; set; } = string.Empty;
        [Required, Compare(nameof(Password))] //Ensures that the ConfirmedPassword field matches the Password field.
        public string? ConfirmedPassword { get; set; } = string.Empty;
        public UserRole Role { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
