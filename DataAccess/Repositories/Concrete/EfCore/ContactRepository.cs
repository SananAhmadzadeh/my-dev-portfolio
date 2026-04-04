namespace DataAccess.Repositories.Concrete.EfCore
{
    public class ContactRepository : EFBaseRepository<Contact, EducationDbContext>, IContactRepository
    {
        public ContactRepository(EducationDbContext context) : base(context)
        {
        }
    }
}
