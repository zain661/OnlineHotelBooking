using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using HotelBooking.Domain.Interfaces;
using HotelBooking.Application.Exceptions;
using HotelBooking.Domain.Entities;
using MediatR;
using HotelBooking.Application.Commands.AuthCommands;
using HotelBooking.Application.DTOs.User.Requests;
using HotelBooking.Application.DTOs.User.Responses;


namespace HotelBooking.Application.Handlers.Auth
{
    public sealed class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegistrationResponse>
    {
        private readonly IUserRepo _userRepo;
        private readonly IMapper _mapper;
        private readonly IValidator<RegisterUserDTO> _validator;

        public RegisterCommandHandler(IUserRepo userRepo, IMapper mapper, IValidator<RegisterUserDTO> validator)
        {
            _userRepo = userRepo;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<RegistrationResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            ValidationResult validationResult = await _validator.ValidateAsync(request.registerUserDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                var errorMessages = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage));
                return new RegistrationResponse(false, errorMessages);
            }
            var registerUser = _mapper.Map<User>(request.registerUserDto);
            var fetchUser = await _userRepo.GetUserByEmailAsync(registerUser.Email);

            if (fetchUser != null)
            {
                throw new UserAlreadyExistException($"A user with email {fetchUser.Email} already exists.");
            }

            registerUser.Password = BCrypt.Net.BCrypt.HashPassword(request.registerUserDto.Password);

            await _userRepo.AddUserAsync(registerUser);

            return new RegistrationResponse(true, "Registration Completed");

        }
    }
}
