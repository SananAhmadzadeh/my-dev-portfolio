using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories.Concrete.EfCore
{
    public class EfGroupRepository:EFBaseRepository<Group,EducationDbContext>,IGroupRepository
    {
        public EfGroupRepository(EducationDbContext context) : base(context)
        {
        }
    }
}
