using Core.Utilities.Result.Abstract;

namespace Business.Services.Abstract
{
    public interface IRolePermissionService
    {
        Task<IDataResult<List<int>>> GetPermissionIdsByRoleAsync(string roleId);
        Task<IResult> SetPermissionsToRoleAsync(string roleId, List<int> permissionIds);
    }
}
