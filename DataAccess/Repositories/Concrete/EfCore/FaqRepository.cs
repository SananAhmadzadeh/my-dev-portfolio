namespace DataAccess.Repositories.Concrete.EfCore
{
    public class FaqRepository : EFBaseRepository<Faq, EducationDbContext>, IFaqRepository
    {
        public FaqRepository(EducationDbContext context) : base(context)
        {
        }
    }
}
