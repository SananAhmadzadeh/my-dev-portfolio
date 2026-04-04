using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs.NotificationDTOs
{
    public class MarkAsReadDto : IDto
    {
        public Guid NotificationId { get; set; }

    }
}
