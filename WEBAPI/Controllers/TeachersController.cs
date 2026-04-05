using Business.Services.Abstract;
using Core.Entities.Concrete.Auth;
using Core.Utilities.Result.Concrete;
using Entities.DTOs.SetPasswordDTOs;
using Entities.DTOs.TeacherDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WEBAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Teacher")]
    public class TeachersController : ControllerBase
    {
        readonly ITeacherService _service;
        private readonly IPasswordResetWithMailService _passwordResetService;

        public TeachersController(ITeacherService service,UserManager<AppUser> userManager, IPasswordResetWithMailService passwordResetWith)
        {
            _service = service;
            _passwordResetService = passwordResetWith;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTeachers()
        {
            var result = await _service.GetAllTeachersAsync();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetTeacherById(Guid id)
        {
            var result = await _service.GetTeacherByIdAsync(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> AddTeacher(CreateTeacherDto createTeacherDto)
        {
            var result = await _service.AddTeacherAsync(createTeacherDto);
            if (result.Success)
                return Ok(result);
            return BadRequest(new ErrorResult("Teacher not added"));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTeacher(Guid id)
        {
            var result = await _service.DeleteTeacherAsync(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(new ErrorResult("Teacher not deleted"));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTeacher(Guid id, UpdateTeacherDto updateTeacherDto)
        {
            var result = await _service.UpdateTeacherAsync(id, updateTeacherDto);

            if (result.Success)
                return Ok(result);
            return BadRequest(new ErrorResult("Teacher not updated"));
        }

        [HttpPost("set-password")]
        public async Task<IActionResult> SetPassword([FromForm] SetPasswordDto dto)
        {
            var result = await _passwordResetService.SetPassword(dto);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }


    }
}
