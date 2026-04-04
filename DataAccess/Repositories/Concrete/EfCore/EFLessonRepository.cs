using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories.Concrete.EfCore
{
    internal class EFLessonRepository : EFBaseRepository<Lesson, EducationDbContext>, ILessonRepository
    {
        public EFLessonRepository(EducationDbContext context) : base(context)
        {
        }
    }
}
