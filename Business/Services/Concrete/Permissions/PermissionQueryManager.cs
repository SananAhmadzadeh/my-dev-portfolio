using Business.Services.Abstract;
using Business.Utilities.Security.Abstract;
using Core.Entities.Concrete.Auth;

namespace Business.Services.Concrete.Permissions
{
    public class PermissionQueryManager : IPermissionQueryService
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IAuthorizationPermissionService _authorizationPermissionService;

        public PermissionQueryManager(
            ICurrentUserService currentUserService,
            IAuthorizationPermissionService authorizationPermissionService)
        {
            _currentUserService = currentUserService;
            _authorizationPermissionService = authorizationPermissionService;
        }

        public async Task<List<Permission>> GetAllAsync()
        {
            var userId = _currentUserService.UserId;
            return await _authorizationPermissionService.GetPermissionsForUserAsync(userId);
        }
    }
}
