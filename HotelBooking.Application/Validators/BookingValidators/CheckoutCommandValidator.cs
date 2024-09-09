using FluentValidation;
using HotelBooking.Application.Commands.BookingCommands;

public class CheckoutCommandValidator : AbstractValidator<CheckoutCommand>
{
    public CheckoutCommandValidator()
    {
        RuleFor(command => command.UserId)
            .NotEmpty().WithMessage("UserId is required.");

        RuleFor(command => command.UserName)
            .NotEmpty().WithMessage("UserName is required.");

        RuleFor(command => command.UserEmail)
            .NotEmpty().EmailAddress().WithMessage("A valid email address is required.");

        RuleFor(command => command.CheckInDate)
            .NotEmpty().WithMessage("Check-in date is required.")
            .Must(BeAValidDate).WithMessage("Check-in date is not valid.");

        RuleFor(command => command.CheckOutDate)
            .NotEmpty().WithMessage("Check-out date is required.")
            .Must(BeAValidDate).WithMessage("Check-out date is not valid.")
            .GreaterThan(command => command.CheckInDate).WithMessage("Check-out date must be after the check-in date.");

        RuleForEach(command => command.RoomSelections)
            .ChildRules(roomSelection =>
            {
                roomSelection.RuleFor(rs => rs.RoomId)
                    .NotEmpty().WithMessage("Room ID is required.");

                roomSelection.RuleFor(rs => rs.PricePerNight)
                    .GreaterThan(0).WithMessage("Price per night must be greater than 0.");
            });

        RuleFor(command => command.PaymentMethod)
            .IsInEnum().WithMessage("Invalid payment method.");
    }

    private bool BeAValidDate(DateTime date)
    {
        return !date.Equals(default(DateTime));
    }
}
