using FluentValidation;
using HotelBooking.Application.DTOs.User.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.Validators
{
    public class LoginValidator: AbstractValidator<LoginUserDTO>
    {
        public LoginValidator() {
            RuleFor(e => e.Email).NotEmpty().WithMessage("Email is required.")
    .EmailAddress().WithMessage("Invalid email format.");
            RuleFor(e =>e.Password).NotEmpty().WithMessage("Password is required.")
    .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");
        }
    }
}
