using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories.Concrete.EfCore
{
    public class EfTeacherRepository : EFBaseRepository<Teacher, EducationDbContext>, ITeacherRepository
    {
        public EfTeacherRepository(EducationDbContext context) : base(context)
        {
        }
    }
}
