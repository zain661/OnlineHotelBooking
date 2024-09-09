using FluentValidation;
using HotelBooking.Application.Commands.HotelCommands;

namespace HotelBooking.Application.Validators.HotelValidators
{
    public class CreateHotelCommandValidator : AbstractValidator<CreateHotelCommand>
    {
        public CreateHotelCommandValidator()
        {
            RuleFor(command => command.Name)
                .NotEmpty().WithMessage("Hotel name is required.");

            RuleFor(command => command.Rating)
                .InclusiveBetween(1, 5).WithMessage("Rating must be between 1 and 5.");

            RuleFor(command => command.StreetAddress)
                .NotEmpty().WithMessage("Street address is required.");

            RuleFor(command => command.Description)
                .NotEmpty().WithMessage("Description is required.");

            RuleFor(command => command.NumberOfRooms)
                .GreaterThan(0).WithMessage("Number of rooms must be greater than zero.");

            RuleFor(command => command.CityId)
                .NotEmpty().WithMessage("City ID is required.");

            RuleFor(command => command.OwnerId)
                .NotEmpty().WithMessage("Owner ID is required.");

            RuleFor(command => command.PhoneNumber)
                .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Invalid phone number format.");

            RuleFor(command => command.Category)
                .IsInEnum().WithMessage("Invalid category value.");
        }
    }
}
