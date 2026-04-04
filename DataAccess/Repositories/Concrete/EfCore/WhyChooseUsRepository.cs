using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories.Concrete.EfCore
{
    public class WhyChooseUsRepository : EFBaseRepository<WhyChooseUs, EducationDbContext>, IWhyChooseUsRepository
    {
        public WhyChooseUsRepository(EducationDbContext context) : base(context)
        {
        }
    }
}
