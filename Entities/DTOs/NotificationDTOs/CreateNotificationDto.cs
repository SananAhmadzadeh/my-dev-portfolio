using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs.NotificationDTOs
{
    public class CreateNotificationDto:IDto
    {
        public string Title { get; set; }
        public string MessageTemplate { get; set; }
        public string RoleId { get; set; }
    }
}
