using Core.DataAccess.Repositories.Abstract;
using Core.Entities.Concrete.Auth;

namespace DataAccess.Repositories.Abstract
{
    public interface IAppUserPermissionRepository : IBaseRepository<AppUserPermission>
    {
        Task<List<AppUserPermission>>GetByUserIdAsync(string userId, params string[] includes);
        Task RemoveByUserIdAsync(string userId);
    }
}
