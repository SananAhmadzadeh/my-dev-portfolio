using Core.Entities.Concrete.Auth;

namespace Business.Utilities.Security.Abstract
{
    public interface IAuthorizationPermissionService
    {
        Task<List<string>> GetUserPermissionsAsync(string userId);
        Task<bool> HasPermissionAsync(string userId, List<string> roles, string permission);
        Task<bool> IsSuperAdmin(string userId);
        Task<List<Permission>> GetPermissionsForUserAsync(string userId);
        Task<bool> CanAssignPermissionAsync(string currentUserId, string targetUserId);
    }
}
