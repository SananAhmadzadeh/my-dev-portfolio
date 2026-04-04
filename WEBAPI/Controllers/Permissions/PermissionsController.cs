using Business.Utilities.Security.Abstract;
using Business.Utilities.Security.Concrete;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]/[action]")]
[ApiExplorerSettings(GroupName = "SuperAdmin")]
public class PermissionsController : ControllerBase
{
    private readonly IAuthorizationPermissionService _permissionService;

    public PermissionsController(IAuthorizationPermissionService permissionService)
    {
        _permissionService = permissionService;
    }

    [HttpGet]
    [HasPermission("PERMISSION.VIEW")]
    public async Task<IActionResult> GetAll()
    {
        // Hazırki istifadəçi
        var currentUserId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(currentUserId))
            return Unauthorized("User not authenticated");

        // Permissions-ları gətir
        var permissions = await _permissionService.GetPermissionsForUserAsync(currentUserId);

        return Ok(new
        {
            Success = true,
            Data = permissions.Select(p => new
            {
                p.Id,
                p.Code,
                p.Description,
                p.IsDelegatable
            })
        });
    }
}
