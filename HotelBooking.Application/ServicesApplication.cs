using HotelBooking.Application.Profiles;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using HotelBooking.Application.Validators;
using HotelBooking.Application.Abstractions;
using HotelBooking.Application.Services;
using HotelBooking.Application.Queries.HotelQueries;
using HotelBooking.Application.MappingProfiles;
using HotelBooking.Application.Validators.HotelValidators;

namespace HotelBooking.Application
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            var assembly = typeof(ServiceCollectionExtensions).Assembly;

            services.AddMediatR(configuration =>
                configuration.RegisterServicesFromAssembly(assembly));

            services.AddAutoMapper(typeof(UserProfile));
            services.AddAutoMapper(typeof(HotelProfile));
            services.AddAutoMapper(typeof(ImageProfile));
            services.AddAutoMapper(typeof(ReviewProfile));
            services.AddAutoMapper(typeof(CityProfile));
            services.AddValidatorsFromAssemblyContaining<LoginValidator>();
            services.AddValidatorsFromAssemblyContaining<RegisterValidator>();
            services.AddValidatorsFromAssemblyContaining<HotelSearchParametersValidator>();
            services.AddValidatorsFromAssemblyContaining<GetHotelsSearchQueryValidator>();
            services.AddValidatorsFromAssemblyContaining<CreateHotelCommandHandler>();
            services.AddValidatorsFromAssemblyContaining<UpdateHotelCommandValidator>();

            // Assuming you're using the assembly scanning registration method


            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IRoomPriceCalculator, RoomPriceCalculator>();


            return services;
        }
    }
}
