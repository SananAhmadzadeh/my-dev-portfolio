using Core.Entities.Concrete.Auth;

namespace DataAccess.Repositories.Concrete.EfCore
{
    public class EfRolePermissionRepository : EFBaseRepository<RolePermission, EducationDbContext>, IRolePermissionRepository
    {
        public EfRolePermissionRepository(EducationDbContext context) : base(context) { }
    }
}
