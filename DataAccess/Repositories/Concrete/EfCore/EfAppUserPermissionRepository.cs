using Core.Entities.Concrete.Auth;

namespace DataAccess.Repositories.Concrete.EfCore
{
    public class EfAppUserPermissionRepository
        : EFBaseRepository<AppUserPermission, EducationDbContext>,
          IAppUserPermissionRepository
    {
        public EfAppUserPermissionRepository(
            EducationDbContext context)
            : base(context)
        {

        }

        public async Task<List<AppUserPermission>>
            GetByUserIdAsync(string userId, params string[] includes)
        {
            return await GetAllAsync(
                x => x.AppUserId == userId,
                includes
            );
        }

        public async Task RemoveByUserIdAsync(string userId)
        {
            var existing = await GetAllAsync(
                x => x.AppUserId == userId
            );

            foreach (var item in existing)
            {
                await Delete(item);
            }
        }
    }
}
