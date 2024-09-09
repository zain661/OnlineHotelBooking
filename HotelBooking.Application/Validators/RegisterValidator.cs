using FluentValidation;
using HotelBooking.Application.DTOs.User.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Application.Validators
{
    public class RegisterValidator: AbstractValidator<RegisterUserDTO>
    {
        public RegisterValidator() {
            RuleFor(e  => e.Email).NotEmpty().WithMessage("Email is required.")
    .EmailAddress().WithMessage("Invalid email format.");
            RuleFor(e =>e.Password).NotEmpty().WithMessage("Password is required.")
    .MinimumLength(6).WithMessage("Password must be at least 6 characters long.").Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
            .Matches(@"[a-z]").WithMessage("Password must contain at least one lowercase letter.")
            .Matches(@"\d").WithMessage("Password must contain at least one number.")
            .Matches(@"[@$!%*?&#]").WithMessage("Password must contain at least one special character.");
            RuleFor(x => x.ConfirmedPassword).Equal(x => x.Password).WithMessage("Passwords do not match.");

        }
    }
}
