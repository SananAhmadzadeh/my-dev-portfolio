using Core.DataAccess.Repositories.Abstract;

namespace DataAccess.Repositories.Concrete.EfCore
{
    public class EfSkillRepository : EFBaseRepository<Skill, EducationDbContext>, ISkillRepository
    {
        public EfSkillRepository(EducationDbContext context) : base(context) { }       
    }
}
