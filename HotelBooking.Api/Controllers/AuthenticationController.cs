using HotelBooking.Application.Abstractions;
using HotelBooking.Application.DTOs.User.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBooking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly ILogger<AuthenticationController> _logger;

        public AuthenticationController(IAuthenticationService authenticationService, ILogger<AuthenticationController> logger)
        {
            _authenticationService = authenticationService;
            _logger = logger;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDTO loginDTO, CancellationToken cancellationToken)
        {
            if (loginDTO == null)
            {
                _logger.LogWarning("Invalid login request received.");
                return BadRequest("Invalid login request.");
            }

            try
            {
                var response = await _authenticationService.LoginAsync(loginDTO, cancellationToken);

                if (response.isLoggedIn)
                {
                    return Ok(response);
                }

                _logger.LogWarning("Invalid credentials for login attempt.");
                return Unauthorized(new { message = "Invalid credentials." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred during login.");
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An error occurred during login.", details = ex.Message });
            }
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenDTO refreshTokenDTO)
        {
            if (refreshTokenDTO == null)
            {
                _logger.LogWarning("Invalid refresh token request received.");
                return BadRequest("Invalid refresh token request.");
            }

            try
            {
                var response = await _authenticationService.RefreshTokenAsync(refreshTokenDTO);

                if (response == null)
                {
                    _logger.LogWarning("Invalid or expired refresh token.");
                    return Unauthorized(new { message = "Invalid or expired refresh token." });
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred during token refresh.");
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An error occurred during token refresh.", details = ex.Message });
            }
        }
    }
}
