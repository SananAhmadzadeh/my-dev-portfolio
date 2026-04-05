using Business.Services.Abstract;
using Entities.DTOs.CourseDTOs;
using Microsoft.AspNetCore.Mvc;

namespace WEBAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _courseService.GetAllCoursesAsync();
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddCourse(CreateCourseDto dto)
        {
            var result = await _courseService.AddCourseAsync(dto);

            if(!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetById(Guid courseId)
        {
            var result = await _courseService.GetCourseByIdAsync(courseId);
            if (result.Success)
            {
                return Ok(result);
            }
            return NotFound(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid courseId)
        {
            var result = await _courseService.Delete(courseId);
            if (result.Success)
            {
                return StatusCode(204, result);
            }
            return BadRequest(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Guid id, UpdateCourseDto updateCourseDto)
        {
            var result = await _courseService.UpdateCourseAsync(id, updateCourseDto);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
