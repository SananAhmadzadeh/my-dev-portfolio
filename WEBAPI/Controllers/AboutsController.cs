using Business.Services.Abstract;
using Entities.DTOs.AboutDTOs;
using Microsoft.AspNetCore.Mvc;

namespace WEBAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly IAboutService _service;

        public AboutsController(IAboutService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAbouts()
        {
            var result = await _service.GetAllAboutsAsync();
            if (result.Success)
                return Ok(result);
            return NotFound(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAboutById(Guid id)
        {
            var result = await _service.GetAboutByIdAsync(id);
            if (result.Success)
                return Ok(result);
            return NotFound(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddAbout([FromBody] CreateAboutDTO createAboutDTO)
        {
            var result = await _service.AddAboutAsync(createAboutDTO);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAbout(Guid aboutId)
        {
            var result = await _service.DeleteAboutAsync(aboutId);
            if (result.Success)
                return NoContent();
            return BadRequest(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAbout(Guid id, UpdateAboutDTO updateAboutDTO)
        {
            var result = await _service.UpdateAboutAsync(id, updateAboutDTO);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
