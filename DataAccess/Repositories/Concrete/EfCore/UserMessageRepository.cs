using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories.Concrete.EfCore
{
    public class UserMessageRepository : EFBaseRepository<UserMessage, EducationDbContext>, IUserMessageRepository
    {
        public UserMessageRepository(EducationDbContext context) : base(context)
        {
        }
    }
}
