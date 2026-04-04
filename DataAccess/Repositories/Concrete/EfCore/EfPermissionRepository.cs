using Core.Entities.Concrete.Auth;

namespace DataAccess.Repositories.Concrete.EfCore
{
    public class EfPermissionRepository
        : EFBaseRepository<Permission, EducationDbContext>,
          IPermissionRepository
    {
        public EfPermissionRepository(EducationDbContext context)
            : base(context) { }
    }

}
