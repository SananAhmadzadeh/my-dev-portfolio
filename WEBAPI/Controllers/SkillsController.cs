using Business.Services.Abstract;
using Business.Utilities.Security.Concrete;
using Entities.DTOs.SkillDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WEBAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillService _service;

        public SkillsController(ISkillService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSkills()
        {
            var result = await _service.GetAllSkillsAsync();

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSkillById(Guid id)
        {
            var result = await _service.GetSkillByIdAsync(id);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        //[Authorize(Roles = "Teacher")]
        //[HasPermission("SKILL.CREATE")]
        [HttpPost]
        public async Task<IActionResult> CreateSkill(CreateSkillDto dto)
        {
            var result = await _service.AddSkillAsync(dto);

            if (!result.Success)
                return BadRequest(result);

            return StatusCode(StatusCodes.Status201Created, result);
        }

        //[Authorize(Roles = "Teacher")]
        //[HasPermission("SKILL.DELETE")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSkill(Guid id)
        {
            var result = await _service.DeleteSkillAsync(id);

            if (!result.Success)
                return BadRequest(result);

            return StatusCode(StatusCodes.Status204NoContent, result);
        }


        //[Authorize(Roles = "Teacher")]
        //[HasPermission("SKILL.UPDATE")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSkill(Guid id, UpdateSkillDto dto)
        {
            var result = await _service.UpdateSkillAsync(id, dto);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
