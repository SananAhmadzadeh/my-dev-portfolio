using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories.Concrete.EfCore
{
    public class StatisticsRepository : EFBaseRepository<Statistics, EducationDbContext>, IStatisticsRepository
    {
        public StatisticsRepository(EducationDbContext context) : base(context)
        {
        }
    }
}
