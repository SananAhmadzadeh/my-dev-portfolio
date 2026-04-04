namespace DataAccess.Repositories.Concrete.EfCore
{
    public class EFVideoRepository : EFBaseRepository<Video, EducationDbContext> , IVideoRepository
    {
        public EFVideoRepository(EducationDbContext _context) : base(_context) { }
    }
}
