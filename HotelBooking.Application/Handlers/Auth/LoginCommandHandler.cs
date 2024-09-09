using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using HotelBooking.Application.Abstractions;
using HotelBooking.Domain.Interfaces;
using HotelBooking.Domain.Entities;
using MediatR;
using HotelBooking.Application.Commands.AuthCommands;
using HotelBooking.Application.DTOs.User.Requests;
using HotelBooking.Application.DTOs.User.Responses;

namespace HotelBooking.Application.Handlers.Auth
{
    public sealed class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
    {
        private readonly IUserRepo _userRepo;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IMapper _mapper;
        private readonly IValidator<LoginUserDTO> _validator;

        public LoginCommandHandler(IUserRepo userRepo, IJwtTokenGenerator jwtTokenGenerator, IMapper mapper, IValidator<LoginUserDTO> validator)
        {
            _userRepo = userRepo;
            _jwtTokenGenerator = jwtTokenGenerator;
            _mapper = mapper;
            _validator = validator;
        }
        public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            ValidationResult validationResult = await _validator.ValidateAsync(request.loginUserDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                var errorMessages = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage));
                return new LoginResponse(false, errorMessages);
            }
            var loginUser = _mapper.Map<User>(request.loginUserDto);
            var fetchUser = await _userRepo.GetUserByEmailAsync(loginUser.Email);
            if (fetchUser == null) return new LoginResponse(false, "User Not Found, Sorry!");

            bool checkPassword = BCrypt.Net.BCrypt.Verify(request.loginUserDto.Password, fetchUser.Password);
            if (!checkPassword) return new LoginResponse(false, "Invalid credentials");

            var token = _jwtTokenGenerator.GenerateToken(fetchUser);
            var refreshToken = _jwtTokenGenerator.GenerateRefreshToken();

            await _userRepo.SaveRefreshTokenAsync(fetchUser.Id, refreshToken, DateTime.UtcNow.AddDays(7));
            return new LoginResponse(true, "Login successful", token, refreshToken);

        }
    }
}
