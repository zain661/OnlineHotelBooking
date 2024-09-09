using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using HotelBooking.Application.Queries.HotelQueries;

namespace HotelBooking.Application.Validators.HotelValidators
{
    public class GetFeaturedDealsQueryValidator : AbstractValidator<GetFeaturedDealsQuery>
    {
        public GetFeaturedDealsQueryValidator()
        {
            RuleFor(query => query.Count)
                .GreaterThan(0).WithMessage("Count must be greater than zero.");
        }
    }

}
