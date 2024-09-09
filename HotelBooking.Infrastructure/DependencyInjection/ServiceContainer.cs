using HotelBooking.Application.Abstractions;
using HotelBooking.Infrastructure.Repositories;
using HotelBooking.Infrastructure.Services;
using HotelBooking.Domain.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;


namespace HotelBooking.Infrastructure.DependencyInjection
{
    public static class ServiceContainer
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HotelBookingDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
    b => b.MigrationsAssembly(typeof(ServiceContainer).Assembly.FullName)),
    ServiceLifetime.Scoped);

            
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!))
                };
            });
            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<IHotelRepo, HotelRepo>();
            services.AddScoped<IRoomRepo, RoomRepo>();
            services.AddScoped<IBookingRepo, BookingRepo>();
            services.AddScoped<ICityRepo, CityRepo>();
            services.AddScoped<IReviewRepo, ReviewRepo>();
            services.AddScoped<IImageRepo, ImageRepo>();
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddScoped<IPdfService, PdfService>();
            services.AddScoped<IInvoiceService, InvoiceService>();
            services.AddScoped<IEmailService, EmailService>();
            return services;
        }
        
    }
}


/*
 Separating infrastructure services from the main application setup (Program.cs) into a dedicated dependency injection class like ServiceContainer has several benefits. This practice is often part of the Dependency Injection (DI) pattern and Clean Architecture principles. Here's a detailed explanation of why and how this is done:
 */
