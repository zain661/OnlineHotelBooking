using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HotelBooking.Application.Queries.CityQueries;
using HotelBooking.Application.Commands.CityCommands;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HotelBooking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CityController> _logger;

        public CityController(IMediator mediator, ILogger<CityController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("top-visited")]
        public async Task<IActionResult> GetTopVisitedCities(CancellationToken cancellationToken)
        {
            try
            {
                var query = new GetTopVisitedCitiesQuery();
                var result = await _mediator.Send(query, cancellationToken);

                if (result == null || !result.Any())
                {
                    _logger.LogInformation("No cities found for top-visited query.");
                    return NotFound(new { message = "No cities found." });
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching top visited cities.");
                return StatusCode(500, new { message = "An error occurred while fetching top visited cities.", details = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetCities()
        {
            try
            {
                var result = await _mediator.Send(new GetCitiesQuery());
                if (result == null || !result.Any())
                {
                    _logger.LogInformation("No cities found.");
                    return NotFound(new { message = "No cities found." });
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching cities.");
                return StatusCode(500, new { message = "An error occurred while fetching cities.", details = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCity(Guid id)
        {
            try
            {
                var result = await _mediator.Send(new GetCityByIdQuery { Id = id });
                if (result == null)
                {
                    _logger.LogInformation($"City with ID {id} not found.");
                    return NotFound(new { message = $"City with ID {id} not found." });
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while fetching city with ID {id}.");
                return StatusCode(500, new { message = $"An error occurred while fetching city with ID {id}.", details = ex.Message });
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateCity([FromBody] CreateCityCommand command)
        {
            if (command == null)
            {
                _logger.LogWarning("Invalid city data provided.");
                return BadRequest(new { message = "Invalid city data provided." });
            }

            try
            {
                var cityId = await _mediator.Send(command); // The result is the Id of the created city
                return CreatedAtAction(nameof(GetCity), new { id = cityId }, new { id = cityId });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the city.");
                return StatusCode(500, new { message = "An error occurred while creating the city.", details = ex.Message });
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCity(Guid id, [FromBody] UpdateCityCommand command)
        {
            if (command == null || id != command.Id)
            {
                _logger.LogWarning("Invalid request. City ID does not match.");
                return BadRequest(new { message = "Invalid request. City ID does not match." });
            }

            try
            {
                await _mediator.Send(command); // No content to return, operation should be successful if no exception is thrown
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the city.");
                return StatusCode(500, new { message = "An error occurred while updating the city.", details = ex.Message });
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(Guid id)
        {
            try
            {
                await _mediator.Send(new DeleteCityCommand { Id = id }); // No content to return, operation should be successful if no exception is thrown
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the city.");
                return StatusCode(500, new { message = "An error occurred while deleting the city.", details = ex.Message });
            }
        }
    }
}
