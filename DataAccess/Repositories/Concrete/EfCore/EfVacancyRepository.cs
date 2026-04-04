namespace DataAccess.Repositories.Concrete.EfCore
{
    public class EfVacancyRepository : EFBaseRepository<Vacancy, EducationDbContext>, IVacancyRepository
    {
        public EfVacancyRepository(EducationDbContext context) : base(context) { }
    }
}
