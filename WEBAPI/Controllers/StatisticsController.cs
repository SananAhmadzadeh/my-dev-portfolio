using Business.Services.Abstract;
using Entities.DTOs.GraduateDTOs;
using Entities.DTOs.StatisticsDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEBAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsService _service;

            public StatisticsController(IStatisticsService service)
            {
                _service = service;
            }

            [HttpGet]
            public async Task<IActionResult> GetAllStatistics()
            {
                var result = await _service.GetAllStatisticsAsync();
                if (!result.Success)
                    return NotFound(result);

                return Ok(result);
            }          

            [HttpPost]
            public async Task<IActionResult> CreateStatistics(CreateStatisticsDto dto)
            {
                var result = await _service.AddStatisticsAsync(dto);
                if (!result.Success)
                    return BadRequest(result);

                return StatusCode(StatusCodes.Status201Created, result);
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteStatistics(Guid id)
            {
                var result = await _service.DeleteStatisticsAsync(id);
                if (!result.Success)
                    return BadRequest(result);

                return StatusCode(StatusCodes.Status204NoContent, result);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateStatistics(Guid id, UpdateStatisticsDto dto)
            {
                var result = await _service.UpdateStatisticsAsync(id, dto);

                if (!result.Success)
                    return BadRequest(result);

                return Ok(result);
            }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStatisticsById(Guid id)
        {
            var result = await _service.GetStatisticsByIdAsync(id);
            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }
    }
    }

