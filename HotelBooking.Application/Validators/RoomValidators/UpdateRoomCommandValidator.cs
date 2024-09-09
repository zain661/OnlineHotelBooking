using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using HotelBooking.Application.Commands.RoomCommands;

namespace HotelBooking.Application.Validators.RoomValidators
{
    public class UpdateRoomCommandValidator : AbstractValidator<UpdateRoomCommand>
    {
        public UpdateRoomCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Room ID is required.");

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
