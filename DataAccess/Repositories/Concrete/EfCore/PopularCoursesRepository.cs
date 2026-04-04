using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories.Concrete.EfCore
{
    public class PopularCoursesRepository : EFBaseRepository<Course, EducationDbContext>, IPopularCoursesRepository
    {
        public PopularCoursesRepository(EducationDbContext context) : base(context)
        {
        }
    }
}
