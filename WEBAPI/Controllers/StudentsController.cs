using Business.Services.Abstract;
using Core.Utilities.Result.Concrete;
using Entities.DTOs.AboutDTOs;
using Entities.DTOs.SetPasswordDTOs;
using Entities.DTOs.StudentDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WEBAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
[ApiExplorerSettings(GroupName = "Student")]

public class StudentsController : ControllerBase
{
    private readonly IStudentService _service;
    private readonly IPasswordResetWithMailService _passwordResetService;
    public StudentsController(IStudentService service, IPasswordResetWithMailService passwordResetWithMailService)
    {
        _service = service;
        _passwordResetService = passwordResetWithMailService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllStudents()
    {
        var result = await _service.GetAllStudentsAsync();

        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest();
    }

    [HttpGet]
    public async Task<IActionResult> GetStudentById(Guid id)
    {
        var result = await _service.GetStudentByIdAsync(id);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest();
    }
    [HttpPost]
    public async Task<IActionResult> AddStudent(CreateStudentDto createStudentDto)
    {
        var result = await _service.AddStudentAsync(createStudentDto);
        if (result.Success)
            return Ok(result);
        return NotFound(result);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStudent(Guid id)
    {
        var result = await _service.DeleteStudentAsync(id);

        if (result.Success)
            return Ok(result);

        return BadRequest(new ErrorResult(result.Message));
    }


    [HttpPut]
    public async Task<IActionResult> UpdateStudent(Guid id, UpdateStudentDto updateStudentDto)
    {
        var result = await _service.UpdateStudentAsync(id, updateStudentDto);

        if (result.Success)
            return Ok(result);
        return BadRequest(new ErrorResult("Student was not updated"));
    }

    [HttpPost("set-password")]
    public async Task<IActionResult> SetPassword(SetPasswordDto dto)
    {
        var result = await _passwordResetService.SetPassword(dto);

        if (!result.Success)
            return BadRequest(result.Message);

        return Ok(result.Message);
    }
}