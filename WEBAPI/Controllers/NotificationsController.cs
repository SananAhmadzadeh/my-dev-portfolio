using Business.Services.Abstract;
using Entities.DTOs.NotificationDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationsController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateNotificationDto dto)
        {
            await _notificationService.CreateAsync(dto);
            return Ok(new { message = "Notification created successfully" });
        }

        [HttpGet]
        public async Task<IActionResult> GetMyNotifications()
        {
            var userId = GetUserId();
            var notifications = await _notificationService.GetMyNotificationsAsync(userId);
            return Ok(notifications);
        }

        [HttpPut]
        public async Task<IActionResult> MarkAsRead([FromBody] MarkAsReadDto dto)
        {
            var userId = GetUserId();
            await _notificationService.MarkAsReadAsync(dto.NotificationId, userId);
            return Ok(new { message = "Notification marked as read" });
        }

        [HttpGet]
        public async Task<IActionResult> GetUnreadCount()
        {
            var userId = GetUserId();
            var notifications = await _notificationService.GetMyNotificationsAsync(userId);

            var unreadCount = notifications.Count(x => !x.IsRead);
            return Ok(new { unreadCount });
        }

        private Guid GetUserId()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)
                ?? User.FindFirst("sub");

            if (userIdClaim == null)
                throw new UnauthorizedAccessException("UserId not found in token");

            return Guid.Parse(userIdClaim.Value);
        }
    }
}
