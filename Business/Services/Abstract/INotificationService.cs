using Entities.DTOs.NotificationDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.Abstract
{
    public interface INotificationService
    {
        Task CreateAsync(CreateNotificationDto dto);
        Task<List<UserNotificationDto>> GetMyNotificationsAsync(Guid userId);
        Task MarkAsReadAsync(Guid notificationId, Guid userId);

    }
}
