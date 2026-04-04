namespace DataAccess.Repositories.Concrete.EfCore
{
    public class EfAboutRepository : EFBaseRepository<About, EducationDbContext>, IAboutRepository
    {
        public EfAboutRepository(EducationDbContext context) : base(context)
        {
        }
    }
}
