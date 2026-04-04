namespace DataAccess.Repositories.Concrete.EfCore;

public class EfStudentRepository : EFBaseRepository<Student, EducationDbContext>, IStudentRepository
{
    public EfStudentRepository(EducationDbContext context) : base(context) { }
}