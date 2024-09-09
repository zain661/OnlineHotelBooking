using HotelBooking.Application.Commands;
using HotelBooking.Application.Commands.HotelCommands;
using HotelBooking.Application.DTOs.Hotel.Requests;
using HotelBooking.Application.DTOs.Hotel.Responses;
using HotelBooking.Application.Exceptions;
using HotelBooking.Application.Queries;
using HotelBooking.Application.Queries.HotelQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using HotelBooking.Application.DTOs.Room.Requests;
using HotelBooking.Application.DTOs.Room.Responses;
using HotelBooking.Application.Queries.RoomQueries;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelBooking.Application.Helpers;
using HotelBooking.Domain.Helpers;
using Microsoft.Extensions.Logging;

namespace HotelBooking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<HotelController> _logger;

        public HotelController(IMediator mediator, ILogger<HotelController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("HotelsSearch")]
        public async Task<ActionResult<PaginatedList<HotelSearchDTO>>> HotelsSearch([FromQuery] HotelSearchParameters hotelSearchParameters)
        {
            _logger.LogInformation("Searching for hotels with parameters: {@HotelSearchParameters}", hotelSearchParameters);

            try
            {
                var query = new GetHotelsSearchQuery(hotelSearchParameters);
                var result = await _mediator.Send(query);

                if (result == null || !result.Items.Any())
                {
                    _logger.LogInformation("No hotels found matching the search criteria.");
                    return NotFound(new { message = "No hotels found matching the search criteria." });
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while searching for hotels.");
                return StatusCode(500, new { message = "An error occurred while searching for hotels.", details = ex.Message });
            }
        }

        [HttpGet("{hotelId:guid}/hotelDetails", Name = "hotelDetails")]
        public async Task<ActionResult<HotelDetailsDTO>> GetHotelDetailsAsync(Guid hotelId)
        {
            _logger.LogInformation("Fetching details for hotel with ID: {HotelId}", hotelId);

            try
            {
                var query = new GetHotelDetailsQuery(hotelId);
                var result = await _mediator.Send(query);

                if (result == null)
                {
                    _logger.LogInformation("Hotel with ID {HotelId} not found.", hotelId);
                    return NotFound(new { message = $"Hotel with ID {hotelId} not found." });
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching details for hotel with ID {HotelId}.", hotelId);
                return StatusCode(500, new { message = $"An error occurred while fetching details for hotel with ID {hotelId}.", details = ex.Message });
            }
        }

        [HttpGet("hotels/{hotelId}/available-rooms")]
        public async Task<ActionResult<PaginatedList<AvailableRoomsDTO>>> GetAvailableRooms(Guid hotelId, [FromQuery] RoomSearchParameters roomSearchParameters)
        {
            _logger.LogInformation("Fetching available rooms for hotel with ID: {HotelId} with parameters: {@RoomSearchParameters}", hotelId, roomSearchParameters);

            try
            {
                var query = new GetAvailableRoomsQuery(hotelId, roomSearchParameters);
                var result = await _mediator.Send(query);

                if (result == null || !result.Items.Any())
                {
                    _logger.LogInformation("No available rooms found for hotel with ID {HotelId}.", hotelId);
                    return NotFound(new { message = $"No available rooms found for hotel with ID {hotelId}." });
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching available rooms for hotel with ID {HotelId}.", hotelId);
                return StatusCode(500, new { message = $"An error occurred while fetching available rooms for hotel with ID {hotelId}.", details = ex.Message });
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateHotel([FromBody] CreateHotelCommand command)
        {
            if (command == null)
            {
                _logger.LogWarning("Invalid hotel data provided.");
                return BadRequest(new { message = "Invalid hotel data provided." });
            }

            _logger.LogInformation("Creating hotel with data: {@CreateHotelCommand}", command);

            try
            {
                var result = await _mediator.Send(command);
                _logger.LogInformation("Hotel created with ID: {HotelId}", result);
                return CreatedAtAction(nameof(GetHotel), new { id = result }, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the hotel.");
                return StatusCode(500, new { message = "An error occurred while creating the hotel.", details = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHotel(Guid id)
        {
            _logger.LogInformation("Fetching hotel with ID: {HotelId}", id);

            try
            {
                var query = new GetHotelByIdQuery { Id = id };
                var result = await _mediator.Send(query);

                if (result == null)
                {
                    _logger.LogInformation("Hotel with ID {HotelId} not found.", id);
                    return NotFound(new { message = $"Hotel with ID {id} not found." });
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching hotel with ID {HotelId}.", id);
                return StatusCode(500, new { message = $"An error occurred while fetching hotel with ID {id}.", details = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetHotels()
        {
            _logger.LogInformation("Fetching all hotels.");

            try
            {
                var query = new GetHotelsQuery();
                var result = await _mediator.Send(query);

                if (result == null || !result.Any())
                {
                    _logger.LogInformation("No hotels found.");
                    return NotFound(new { message = "No hotels found." });
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching hotels.");
                return StatusCode(500, new { message = "An error occurred while fetching hotels.", details = ex.Message });
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHotel(Guid id, [FromBody] UpdateHotelCommand command)
        {
            if (command == null || id != command.Id)
            {
                _logger.LogWarning("Invalid request. Hotel ID does not match.");
                return BadRequest(new { message = "Invalid request. Hotel ID does not match." });
            }

            _logger.LogInformation("Updating hotel with ID: {HotelId} with data: {@UpdateHotelCommand}", id, command);

            try
            {
                await _mediator.Send(command);
                _logger.LogInformation("Hotel with ID {HotelId} updated successfully.", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the hotel with ID {HotelId}.", id);
                return StatusCode(500, new { message = "An error occurred while updating the hotel.", details = ex.Message });
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(Guid id)
        {
            _logger.LogInformation("Deleting hotel with ID: {HotelId}", id);

            try
            {
                await _mediator.Send(new DeleteHotelCommand { Id = id });
                _logger.LogInformation("Hotel with ID {HotelId} deleted successfully.", id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting hotel with ID {HotelId}.", id);
                return StatusCode(500, new { message = $"An error occurred while deleting hotel with ID {id}.", details = ex.Message });
            }
        }

        [HttpGet("FeaturedDeals")]
        public async Task<ActionResult<IEnumerable<FeaturedDealDTO>>> FeaturedDealsHotels(int count = 3)
        {
            _logger.LogInformation("Fetching featured deals with count: {Count}", count);

            try
            {
                var query = new GetFeaturedDealsQuery(count);
                var result = await _mediator.Send(query);

                if (result == null || !result.Any())
                {
                    _logger.LogInformation("No featured deals found.");
                    return NotFound(new { message = "No featured deals found." });
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching featured deals.");
                return StatusCode(500, new { message = "An error occurred while fetching featured deals.", details = ex.Message });
            }
        }
    }
}
