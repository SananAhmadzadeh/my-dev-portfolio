using Business.Services.Abstract;
using Entities.DTOs.GraduateDTOs;
using Microsoft.AspNetCore.Mvc;

namespace WEBAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class GraduatesController : ControllerBase
    {
        private readonly IGraduateService _service;

        public GraduatesController(IGraduateService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGraduates()
        {
            var result = await _service.GetAllGraduatesAsync();
            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGraduateById(Guid id)
        {
            var result = await _service.GetGraduateByIdAsync(id);
            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGraduate(Guid id)
        {
            var result = await _service.DeleteGraduateAsync(id);
            if (!result.Success)
                return BadRequest(result);

            return StatusCode(StatusCodes.Status204NoContent, result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGraduate(Guid id, UpdateGraduateDto dto)
        {
            var result = await _service.UpdateGraduateAsync(id, dto);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
