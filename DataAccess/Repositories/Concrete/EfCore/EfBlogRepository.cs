namespace DataAccess.Repositories.Concrete.EfCore;

public class EfBlogRepository : EFBaseRepository<Blog, EducationDbContext>, IBlogRepository
{
    public EfBlogRepository(EducationDbContext context) : base(context)
    {
    }
}
