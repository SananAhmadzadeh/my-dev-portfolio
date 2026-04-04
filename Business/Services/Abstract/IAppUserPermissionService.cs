using Core.Utilities.Result.Abstract;

namespace Business.Services.Abstract
{
    public interface IAppUserPermissionService
    {
        Task<IDataResult<List<int>>> GetUserPermissionIdsAsync(string currentUserId, string targetUserId);
        Task<IResult> SetUserPermissionsAsync(string currentUserId, string targetUserId, List<int> permissionIds);
    }
}


