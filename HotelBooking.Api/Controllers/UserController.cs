using HotelBooking.Application.Abstractions;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using HotelBooking.Application.Commands.AuthCommands;
using HotelBooking.Application.Exceptions;
using HotelBooking.Application.DTOs.User.Requests;
using HotelBooking.Application.DTOs.User.Responses;
using HotelBooking.Application.DTOs.Hotel.Responses;
using HotelBooking.Application.Queries.UserQueries;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBooking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<UserController> _logger;

        public UserController(IMediator mediator, ILogger<UserController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponse>> UserRegister(RegisterUserDTO registerUserDTO)
        {
            try
            {
                _logger.LogInformation("Attempting to register user with email: {Email}", registerUserDTO.Email);

                var command = new RegisterCommand(registerUserDTO);
                var result = await _mediator.Send(command);

                _logger.LogInformation("User registered successfully with email: {Email}", registerUserDTO.Email);
                return Ok(result);
            }
            catch (UserAlreadyExistException ex)
            {
                _logger.LogWarning(ex, "Registration failed for user with email: {Email}. Error: {Message}", registerUserDTO.Email, ex.Message);
                return BadRequest(new RegistrationResponse(false, ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while registering user with email: {Email}", registerUserDTO.Email);
                return StatusCode(500, "An unexpected error occurred.");
            }
        }

        [HttpGet("UserRecentlyVisitedHotels")]
        public async Task<ActionResult<List<HotelDTO>>> UserRecentlyVisitedHotels(string Email, int Count)
        {
            try
            {
                _logger.LogInformation("Fetching recently visited hotels for user with email: {Email}. Count: {Count}", Email, Count);

                var query = new GetUser_sRecentlyVisitedHotelsQuery(Email, Count);
                var result = await _mediator.Send(query);

                _logger.LogInformation("Successfully fetched {Count} recently visited hotels for user with email: {Email}", result.Count, Email);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching recently visited hotels for user with email: {Email}", Email);
                return StatusCode(500, "An unexpected error occurred.");
            }
        }
    }
}
