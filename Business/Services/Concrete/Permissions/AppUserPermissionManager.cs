using Business.Services.Abstract;
using Business.Utilities.Security.Abstract;
using Core.Entities.Concrete.Auth;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.UnitOfWork.Abstract;

public class AppUserPermissionManager : IAppUserPermissionService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthorizationPermissionService _authorizationPermissionService;

    public AppUserPermissionManager(
        IUnitOfWork unitOfWork,
        IAuthorizationPermissionService authorizationPermissionService)
    {
        _unitOfWork = unitOfWork;
        _authorizationPermissionService = authorizationPermissionService;
    }

    public async Task<IDataResult<List<int>>> GetUserPermissionIdsAsync(
        string currentUserId,
        string targetUserId)
    {
        if (!await _authorizationPermissionService
            .CanAssignPermissionAsync(currentUserId, targetUserId))
        {
            return new ErrorDataResult<List<int>>(
                null,
                "You do not have permission to view this user's permissions");
        }

        var result = await _unitOfWork
            .AppUserPermissionRepository
            .GetByUserIdAsync(targetUserId);

        return new SuccessDataResult<List<int>>(
            result.Select(x => x.PermissionId).ToList(),
            "User permissions listed");
    }

    public async Task<IResult> SetUserPermissionsAsync(
        string currentUserId,
        string targetUserId,
        List<int> permissionIds)
    {
        if (!await _authorizationPermissionService
            .CanAssignPermissionAsync(currentUserId, targetUserId))
        {
            return new ErrorResult("No permission to assign");
        }

        var currentUserPermissions =
            await _authorizationPermissionService
                .GetPermissionsForUserAsync(currentUserId);

        // 🔐 Yalnız delegatable olanları verə bilər
        var allowedIds = currentUserPermissions
            .Where(p => p.IsDelegatable)
            .Select(p => p.Id)
            .ToList();

        if (permissionIds.Any(pid => !allowedIds.Contains(pid)))
            return new ErrorResult(
                "You cannot assign permissions you do not have or that are not delegatable");

        await _unitOfWork.AppUserPermissionRepository
            .RemoveByUserIdAsync(targetUserId);

        foreach (var pid in permissionIds.Distinct())
        {
            await _unitOfWork.AppUserPermissionRepository.AddAsync(
                new AppUserPermission
                {
                    AppUserId = targetUserId,
                    PermissionId = pid,
                    GrantedByUserId = currentUserId
                });
        }

        await _unitOfWork.SaveAsync();

        return new SuccessResult("Permissions updated successfully");
    }
}
