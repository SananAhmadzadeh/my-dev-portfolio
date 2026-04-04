using Core.Entities.Abstract;
using Core.Entities.Concrete.Auth;
using Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class UserNotification:BaseEntity,IEntity
    {
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public Guid NotificationId { get; set; }
        public Notification Notification { get; set; }
        public bool IsRead { get; set; } = false;
        public DateTime? ReadAt { get; set; }
    }
}
