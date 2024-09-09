using FluentValidation;
using HotelBooking.Application.Commands.CityCommands;

public class UpdateCityCommandValidator : AbstractValidator<UpdateCityCommand>
{
    public UpdateCityCommandValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty().WithMessage("City ID is required.");

        RuleFor(command => command.Name)
            .NotEmpty().WithMessage("City name is required.")
            .MaximumLength(100).WithMessage("City name must not exceed 100 characters.");

        RuleFor(command => command.Country)
            .NotEmpty().WithMessage("Country name is required.")
            .MaximumLength(100).WithMessage("Country name must not exceed 100 characters.");

        RuleFor(command => command.PostOffice)
            .NotEmpty().WithMessage("Post office is required.")
            .MaximumLength(50).WithMessage("Post office must not exceed 50 characters.");
    }
}
