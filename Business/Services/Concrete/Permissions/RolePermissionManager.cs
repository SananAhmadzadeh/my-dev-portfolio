using Business.Services.Abstract;
using Business.Utilities.Security.Abstract;
using Core.Entities.Concrete.Auth;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.UnitOfWork.Abstract;
using Microsoft.AspNetCore.Identity;

namespace Business.Services.Concrete.Permissions
{
    public class RolePermissionManager : IRolePermissionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthorizationPermissionService _authorizationPermissionService;
        public RolePermissionManager(IUnitOfWork unitOfWork, IAuthorizationPermissionService authorizationPermissionService)
        {
            _unitOfWork = unitOfWork;
            _authorizationPermissionService = authorizationPermissionService;
        }

        public async Task<IDataResult<List<int>>> GetPermissionIdsByRoleAsync(string roleId)
        {
            var validationResult = await _authorizationPermissionService.IsSuperAdmin(roleId);

            if (validationResult)
            {
                return new ErrorDataResult<List<int>>("SuperAdminin icazələrini görmək və müdaxilə etmək qadağandır");
            }
            else
            {
                var rolePermissions = await _unitOfWork
                .RolePermissionRepository
                .GetAllAsync(rp => rp.RoleId == roleId);

                return new SuccessDataResult<List<int>>(rolePermissions
                    .Select(rp => rp.PermissionId)
                    .ToList());
            }
        }

        public async Task<IResult> SetPermissionsToRoleAsync(string roleId, List<int> permissionIds)
        {
            var validationResult =await _authorizationPermissionService.IsSuperAdmin(roleId);

            if (validationResult)
            {
                return new ErrorResult("SuperAdminin icazələrini görmək və müdaxilə etmək qadağandır");
            }
            else
            {
                var oldPermissions = await _unitOfWork
                            .RolePermissionRepository
                            .GetAllAsync(rp => rp.RoleId == roleId);

                foreach (var oldPermission in oldPermissions)
                {
                    await _unitOfWork
                        .RolePermissionRepository
                        .Delete(oldPermission);
                }

                foreach (var permissionId in permissionIds)
                {
                    var rolePermission = new RolePermission
                    {
                        RoleId = roleId,
                        PermissionId = permissionId
                    };

                    await _unitOfWork
                        .RolePermissionRepository
                        .AddAsync(rolePermission);
                }

                await _unitOfWork.SaveAsync();

                return new SuccessResult();
            }

        }
    }
}
