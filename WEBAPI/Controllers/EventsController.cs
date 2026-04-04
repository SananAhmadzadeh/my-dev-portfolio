using Business.Services.Abstract;
using Entities.DTOs.Events;
using Entities.DTOs.Recommendations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEBAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _service;
        public EventsController(IEventService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEvent()
        {
            var result = await _service.GetAllEventAsync();
            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventById(Guid id)
        {
            var result = await _service.GetEventById(id);
            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent(CreateEventDto dto)
        {
            var result = await _service.AddEventAsync(dto);
            if (!result.Success)
                return BadRequest(result);

            return StatusCode(StatusCodes.Status201Created, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(Guid id)
        {
            var result = await _service.DeleteEventAsync(id);
            if (!result.Success)
                return BadRequest(result);

            return StatusCode(StatusCodes.Status204NoContent, result);
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvent(UpdateEventDto dto, Guid id)
        {
            var result = await _service.UpdateEventAsync(dto,id);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
