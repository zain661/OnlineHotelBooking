using FluentValidation;
using HotelBooking.Application.Commands.RoomCommands;

namespace HotelBooking.Application.Validators
{
    public class CreateRoomCommandValidator : AbstractValidator<CreateRoomCommand>
    {
        public CreateRoomCommandValidator()
        {
            RuleFor(x => x.RoomTypeId)
                .NotEmpty().WithMessage("RoomTypeId is required.");

            RuleFor(x => x.HotelId)
                .NotEmpty().WithMessage("HotelId is required.");

            RuleFor(x => x.AdultsCapacity)
                .GreaterThan(0).WithMessage("AdultsCapacity must be greater than 0.");

            RuleFor(x => x.ChildrenCapacity)
                .GreaterThanOrEqualTo(0).WithMessage("ChildrenCapacity cannot be negative.");
        }
    }
}