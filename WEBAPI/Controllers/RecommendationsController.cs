using Business.Services.Abstract;
using DataAccess.Repositories.Abstract;
using Entities.DTOs.Recommendations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEBAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RecommendationsController : ControllerBase
    {
        private readonly IRecommendationService _service;
        public RecommendationsController(IRecommendationService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRecommendation()
        {
            var result = await _service.GetAllRecommendationAsync();
            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecommendationById(Guid id)
        {
            var result = await _service.GetRecommendationById(id);
            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRecommendation(CreateRecommendationDto dto)
        {
            var result = await _service.AddRecommendationAsync(dto);
            if (!result.Success)
                return BadRequest(result);

            return StatusCode(StatusCodes.Status201Created, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecommendation(Guid id)
        {
            var result = await _service.DeleteRecommendationAsync(id);
            if (!result.Success)
                return BadRequest(result);

            return StatusCode(StatusCodes.Status204NoContent, result);
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGraduate(Guid id, UpdateRecommendationDto dto)
        {
            var result = await _service.UpdateRecommendationAsync(id, dto);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }





    }
}
