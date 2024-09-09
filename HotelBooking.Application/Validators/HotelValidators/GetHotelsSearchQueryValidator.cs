using FluentValidation;
using HotelBooking.Application.Queries.HotelQueries;

namespace HotelBooking.Application.Validators.HotelValidators
{
    public class GetHotelsSearchQueryValidator : AbstractValidator<GetHotelsSearchQuery>
    {
        public GetHotelsSearchQueryValidator()
        {
            RuleFor(q => q.HotelSearchParameters)
                .SetValidator(new HotelSearchParametersValidator());
        }
    }
}
