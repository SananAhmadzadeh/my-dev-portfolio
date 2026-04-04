namespace DataAccess.Repositories.Concrete.EfCore
{
    public class GraduateRepository : EFBaseRepository<Graduate, EducationDbContext>, IGraduateRepository
    {
        public GraduateRepository(EducationDbContext context) : base(context)
        {
        }
        public class EfGraduateRepository : EFBaseRepository<Graduate, EducationDbContext>, IGraduateRepository
        {
            public EfGraduateRepository(EducationDbContext context) : base(context) { }
        }
    }
}
