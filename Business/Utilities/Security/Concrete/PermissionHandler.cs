using Business.Utilities.Security.Abstract;
using Business.Utilities.Security.Concrete;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

public class PermissionHandler : AuthorizationHandler<PermissionRequirement>
{
    private readonly IAuthorizationPermissionService _permissionService;

    public PermissionHandler(IAuthorizationPermissionService permissionService)
    {
        _permissionService = permissionService;
    }

    protected override async Task HandleRequirementAsync( AuthorizationHandlerContext context, PermissionRequirement requirement)
    {
        var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId == null) return;

        var roles = context.User.FindAll(ClaimTypes.Role)
            .Select(x => x.Value)
            .ToList();

        if (await _permissionService.HasPermissionAsync(
            userId, roles, requirement.Permission))
        {
            context.Succeed(requirement);
        }
    }
}
