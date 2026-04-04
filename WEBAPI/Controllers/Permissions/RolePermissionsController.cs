using Business.Services.Abstract;
using Business.Utilities.Security.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/admin/[controller]/[action]")]
[ApiExplorerSettings(GroupName = "SuperAdmin")]
[Authorize(Roles = "SuperAdmin, Admin")]
public class RolePermissionsController : ControllerBase
{
    private readonly IRolePermissionService _rolePermissionService;
    public RolePermissionsController(IRolePermissionService rolePermissionService)
    {
        _rolePermissionService = rolePermissionService;
    }

    [HttpGet("{roleId}/permissions")]
    [HasPermission("PERMISSION.VIEW")]
    public async Task<IActionResult> GetRolePermissions(string roleId)
    {
        var permissionIds = await _rolePermissionService.GetPermissionIdsByRoleAsync(roleId);

        if(!permissionIds.Success)
        {
            return BadRequest(permissionIds.Message);
        }

        return Ok(permissionIds);
    }

    [HttpPost("{roleId}/permissions")]
    [HasPermission("PERMISSION.ASSIGN")]
    public async Task<IActionResult> SetRolePermissions(string roleId, [FromBody] List<int> permissionIds)
    {
        var result = await _rolePermissionService.SetPermissionsToRoleAsync(roleId, permissionIds);

        if(!result.Success)
        {
            return BadRequest(result.Message);
        }

        return NoContent();
    }
}
