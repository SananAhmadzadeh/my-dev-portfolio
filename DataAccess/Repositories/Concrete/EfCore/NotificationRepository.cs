using Core.DataAccess.Repositories.Abstract;
using Core.DataAccess.Repositories.Concrete;
using DataAccess.Repositories.Abstract;
using Entities.Concrete;
using System;

namespace DataAccess.Repositories.Concrete.EfCore
{
    public class NotificationRepository :EFBaseRepository<Notification,EducationDbContext>, INotificationRepository
    {
        public NotificationRepository(EducationDbContext context) : base(context)
        {
        }
    }
}
