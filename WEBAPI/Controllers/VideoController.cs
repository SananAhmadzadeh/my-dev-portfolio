using Business.Services.Abstract;
using Business.Utilities.Security.Concrete;
using Entities.DTOs.VideoDTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/admin/[controller]/[action]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private readonly IVideoService _videoService;

        public VideoController(IVideoService videoService)
        {
            _videoService = videoService;
        }

        [HasPermission("VIDEO.READ")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _videoService.GetAllVideosAsync();
            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Data);
        }

        [HasPermission("VIDEO.READ")]
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _videoService.GetVideoByIdAsync(id);
            if (!result.Success)
                return NotFound(result.Message);

            return Ok(result.Data);
        }

        [HasPermission("VIDEO.CREATE")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateVideoDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _videoService.AddVideoAsync(dto);
            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }

        [HasPermission("VIDEO.UPDATE")]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateVideoDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _videoService.UpdateVideoAsync(id, dto);
            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }

        [HasPermission("VIDEO.DELETE")]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _videoService.DeleteVideoAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }
    }
}