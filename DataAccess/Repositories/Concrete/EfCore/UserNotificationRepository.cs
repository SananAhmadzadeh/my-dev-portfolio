using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories.Concrete.EfCore
{
    public class UserNotificationRepository:EFBaseRepository<UserNotification,EducationDbContext>, IUserNotificationRepository
    {
        public UserNotificationRepository(EducationDbContext context) : base(context) { 
        }
    }
}
