using Core.DataAccess.Repositories.Concrete.EfCore;
using DataAccess.EFCore;
using DataAccess.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories.Concrete.EfCore
{
    public class EfCourseRepository : EFBaseRepository<Course, EducationDbContext>, ICourseRepository
    {
        public EfCourseRepository(EducationDbContext context) : base(context)
        {
        }
    }
}
