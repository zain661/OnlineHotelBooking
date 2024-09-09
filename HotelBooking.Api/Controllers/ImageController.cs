using HotelBooking.Application.Queries.ImageQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace HotelBooking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ImageController> _logger;

        public ImageController(IMediator mediator, ILogger<ImageController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("hotel/{hotelId:guid}")]
        public async Task<IActionResult> GetHotelImages(Guid hotelId)
        {
            try
            {
                _logger.LogInformation("Fetching images for hotel with ID: {HotelId}", hotelId);

                var query = new GetHotelImagesQuery(hotelId);
                var result = await _mediator.Send(query);

                if (result == null)
                {
                    _logger.LogWarning("No images found for hotel with ID: {HotelId}", hotelId);
                    return NotFound(new { message = $"No images found for hotel with ID {hotelId}." });
                }

                _logger.LogInformation("Successfully fetched images for hotel with ID: {HotelId}", hotelId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching images for hotel with ID: {HotelId}", hotelId);
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An error occurred while fetching images.", details = ex.Message });
            }
        }
    }
}
