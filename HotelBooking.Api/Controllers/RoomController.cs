using HotelBooking.Application.Commands.RoomCommands;
using HotelBooking.Application.Queries.RoomQueries;
using HotelBooking.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<RoomController> _logger;

        public RoomController(IMediator mediator, ILogger<RoomController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        // GET: api/room
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetRooms()
        {
            try
            {
                _logger.LogInformation("Fetching all rooms.");

                var rooms = await _mediator.Send(new GetRoomsQuery());

                _logger.LogInformation("Successfully fetched {Count} rooms.", rooms.Count);
                return Ok(rooms);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching rooms.");
                return StatusCode(500, new { message = "An error occurred while fetching rooms.", details = ex.Message });
            }
        }

        // GET: api/room/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoomById(Guid id)
        {
            try
            {
                _logger.LogInformation("Fetching room with ID: {RoomId}", id);

                var room = await _mediator.Send(new GetRoomByIdQuery { Id = id });

                if (room == null)
                {
                    _logger.LogWarning("Room with ID: {RoomId} not found.", id);
                    return NotFound(new { message = "Room not found." });
                }

                _logger.LogInformation("Successfully fetched room with ID: {RoomId}", id);
                return Ok(room);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching room with ID: {RoomId}", id);
                return StatusCode(500, new { message = "An error occurred while fetching the room.", details = ex.Message });
            }
        }

        // POST: api/room
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult> CreateRoom([FromBody] CreateRoomCommand command)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid model state for creating room.");
                return BadRequest(ModelState);
            }

            try
            {
                _logger.LogInformation("Creating new room with data: {@Command}", command);

                var roomId = await _mediator.Send(command);

                _logger.LogInformation("Room created successfully with ID: {RoomId}", roomId);
                return CreatedAtAction(nameof(GetRoomById), new { id = roomId }, new { id = roomId, message = "Room created successfully." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the room.");
                return StatusCode(500, new { message = "An error occurred while creating the room.", details = ex.Message });
            }
        }

        // PUT: api/room/{id}
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateRoom(Guid id, [FromBody] UpdateRoomCommand command)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid model state for updating room.");
                return BadRequest(ModelState);
            }

            try
            {
                _logger.LogInformation("Updating room with ID: {RoomId} with data: {@Command}", id, command);

                command.Id = id;
                var result = await _mediator.Send(command);

                if (result == null)
                {
                    _logger.LogWarning("Room with ID: {RoomId} not found for update.", id);
                    return NotFound(new { message = "Room not found." });
                }

                _logger.LogInformation("Room with ID: {RoomId} updated successfully.", id);
                return Ok(new { id = result, message = "Room updated successfully." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating room with ID: {RoomId}", id);
                return StatusCode(500, new { message = "An error occurred while updating the room.", details = ex.Message });
            }
        }

        // DELETE: api/room/{id}
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRoom(Guid id)
        {
            try
            {
                _logger.LogInformation("Deleting room with ID: {RoomId}", id);

                await _mediator.Send(new DeleteRoomCommand { Id = id });

                _logger.LogInformation("Room with ID: {RoomId} deleted successfully.", id);
                return Ok(new { message = "Room deleted successfully." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting room with ID: {RoomId}", id);
                return StatusCode(500, new { message = "An error occurred while deleting the room.", details = ex.Message });
            }
        }
    }
}
