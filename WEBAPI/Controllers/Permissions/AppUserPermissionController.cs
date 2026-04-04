using Business.Services.Abstract;
using Business.Utilities.Security.Concrete;
using Core.Entities.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

[ApiController]
[Route("api/[controller]/[action]")]
[Authorize]
[ApiExplorerSettings(GroupName = "SuperAdmin")]

public class AppUserPermissionController : ControllerBase
{
    private readonly IAppUserPermissionService _service;

    public AppUserPermissionController(IAppUserPermissionService service)
    {
        _service = service;
    }

    [HasPermission("PERMISSION.VIEW")]
    [HttpGet("{userId}")]
    public async Task<IActionResult> GetUserPermissions(string userId)
    {
        var currentUserId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

        var result = await _service.GetUserPermissionIdsAsync(currentUserId, userId);

        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }

    [HasPermission("PERMISSION.ASSIGN")]
    [HttpPost]
    public async Task<IActionResult> SetUserPermissions([FromBody] SetUserPermissionDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var currentUserId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

        var result = await _service.SetUserPermissionsAsync(currentUserId, dto.AppUserId, dto.PermissionIds);

        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }
}
