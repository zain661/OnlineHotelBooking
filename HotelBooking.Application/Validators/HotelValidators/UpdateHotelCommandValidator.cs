using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using HotelBooking.Application.Commands.HotelCommands;

namespace HotelBooking.Application.Validators.HotelValidators
{
    public class UpdateHotelCommandValidator : AbstractValidator<UpdateHotelCommand>
    {
        public UpdateHotelCommandValidator()
        {
            RuleFor(command => command.Id)
                .NotEmpty().WithMessage("Hotel ID is required.");

            RuleFor(command => command.Name)
                .NotEmpty().WithMessage("Hotel name is required.");

            RuleFor(command => command.StarRate)
                .InclusiveBetween(1, 5).WithMessage("Star rate must be between 1 and 5.");

            RuleFor(command => command.Owner)
                .NotEmpty().WithMessage("Owner ID is required.");

            RuleFor(command => command.CityId)
                .NotEmpty().WithMessage("City ID is required.");
        }
    }
}
