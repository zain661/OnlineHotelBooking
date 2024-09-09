using HotelBooking.Application.Commands.BookingCommands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace HotelBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<BookingController> _logger;

        public BookingController(IMediator mediator, ILogger<BookingController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost("checkout")]
        public async Task<IActionResult> Checkout([FromBody] CheckoutCommand command)
        {
            if (command == null)
            {
                _logger.LogWarning("Invalid checkout request received.");
                return BadRequest(new { message = "Invalid request. Please provide valid booking information." });
            }

            try
            {
                var result = await _mediator.Send(command);

                if (result == null)
                {
                    _logger.LogWarning("One or more rooms are not available for the selected dates.");
                    return BadRequest(new { message = "One or more rooms are not available for the selected dates." });
                }

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning(ex, "Argument error during checkout.");
                return BadRequest(new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogWarning(ex, "Invalid operation during checkout.");
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the booking.");
                return StatusCode(500, new { message = "An error occurred while processing the booking.", details = ex.Message });
            }
        }
    }
}
