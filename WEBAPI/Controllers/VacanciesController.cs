using Business.Services.Abstract;
using Entities.DTOs.VacancyDTOs;
using Microsoft.AspNetCore.Mvc;

namespace WEBAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VacanciesController : ControllerBase
    {
        private readonly IVacancyService _service;

        public VacanciesController(IVacancyService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVacancies()
        {
            var result = await _service.GetAllVacanciesAsync();

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVacancyById(Guid id)
        {
            var result = await _service.GetVacancyByIdAsync(id);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateVacancy(CreateVacancyDto dto)
        {
            var result = await _service.AddVacancyAsync(dto);

            if (!result.Success)
                return BadRequest(result);

            return StatusCode(StatusCodes.Status201Created, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVacancy(Guid id)
        {
            var result = await _service.DeleteVacancyAsync(id);

            if (!result.Success)
                return BadRequest(result);

            return StatusCode(StatusCodes.Status204NoContent, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVacancy(Guid id, UpdateVacancyDto dto)
        {
            var result = await _service.UpdateVacancyAsync(id, dto);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
