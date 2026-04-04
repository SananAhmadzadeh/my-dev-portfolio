using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories.Concrete.EfCore
{
    public class EfTopicRepository:EFBaseRepository<Topic,EducationDbContext>, ITopicRepository
    {
        public EfTopicRepository(EducationDbContext context) : base(context)
        {
        }
    }
}
