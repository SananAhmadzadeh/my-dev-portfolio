using Business.Services.Abstract;
using Entities.DTOs.LessonDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEBAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly ILessonService _service;

        public LessonController(ILessonService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult>  GetAllLessons()
        {
            var result = await _service.GetAllLessontsAsync();
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest();         
        }

        [HttpGet]
        public async Task<IActionResult> GetLessonById(Guid id)
        {
            var result = await _service.GetLessontByIdAsync(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
            
        }

        [HttpPost]
        public async Task<IActionResult> AddLesson(CreateLessonDTO DTO)
        {
           var result = await _service.AddLessonDtoAsync(DTO);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteLesson(Guid id)
        {
           var result = await _service.DeleteLessonDtoAsync(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLesson( Guid id, UpdateLessonDTO DTO)
        {
            var result = await _service.UpdateLessonDtoAsync( id,DTO);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();

        }
    }
}
