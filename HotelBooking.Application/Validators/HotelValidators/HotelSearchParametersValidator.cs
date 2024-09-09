using FluentValidation;
using HotelBooking.Application.DTOs.Hotel.Requests;
using HotelBooking.Domain.Helpers;

namespace HotelBooking.Application.Validators.HotelValidators
{
    public class HotelSearchParametersValidator : AbstractValidator<HotelSearchParameters>
    {
        public HotelSearchParametersValidator()
        {
            RuleFor(q => q.PageNumber)
                .GreaterThan(0).WithMessage("Page number must be greater than zero.");

            RuleFor(q => q.PageSize)
                .GreaterThan(0).WithMessage("Page size must be greater than zero.");

            RuleFor(q => q.CheckIn)
                .LessThanOrEqualTo(q => q.CheckOut).When(q => q.CheckIn.HasValue && q.CheckOut.HasValue)
                .WithMessage("Check-in date must be before or equal to check-out date.");

            RuleFor(q => q.AdultCapacity)
                .GreaterThanOrEqualTo(0).WithMessage("Adult capacity must be non-negative.");

            RuleFor(q => q.ChildrenCapacity)
                .GreaterThanOrEqualTo(0).WithMessage("Children capacity must be non-negative.");
        }
    }
}
