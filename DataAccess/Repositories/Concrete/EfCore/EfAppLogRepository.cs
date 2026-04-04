using Core.Logging;

namespace DataAccess.Repositories.Concrete.EfCore
{
    public class EfAppLogRepository : EFBaseRepository<AppLog, EducationDbContext>, IAppLogRepository
    {
        public EfAppLogRepository(EducationDbContext context) : base(context) { }
    }
}
