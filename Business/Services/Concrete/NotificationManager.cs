using AutoMapper;
using Business.Services.Abstract;
using Core.Entities.Concrete.Auth;
using DataAccess.UnitOfWork.Abstract;
using Entities.Concrete;
using Entities.DTOs.NotificationDTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using WebAPI.Hubs;

namespace Business.Services.Concrete
{
    public class NotificationManager : INotificationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IHubContext<NotificationHub> _hubContext;

        public NotificationManager(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IHubContext<NotificationHub> hubContext)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _hubContext = hubContext;
        }

        public async Task CreateAsync(CreateNotificationDto dto)
        {
            var notification = _mapper.Map<Notification>(dto);
            notification.CreatedAt = DateTime.UtcNow;

            await _unitOfWork.NotificationRepository.AddAsync(notification);
            await _unitOfWork.SaveAsync();

            var role = await _roleManager.FindByIdAsync(dto.RoleId);
            if (role == null)
                throw new Exception("Role not found");

            var users = await _userManager.GetUsersInRoleAsync(role.Name);

            foreach (var user in users)
            {
                var userNotification = new UserNotification
                {
                    AppUserId = user.Id.ToString(),
                    NotificationId = notification.Id,
                    IsRead = false
                };

                await _unitOfWork.UserNotificationRepository.AddAsync(userNotification);

                var notificationDto = new UserNotificationDto
                {
                    Id = userNotification.Id,
                    Title = notification.Title,
                    Message = notification.MessageTemplate,
                    IsRead = false,
                    CreatedAt = notification.CreatedAt
                };

                await _hubContext.Clients.User(user.Id.ToString())
                                         .SendAsync("ReceiveNotification", notificationDto);
            }
            await _unitOfWork.SaveAsync();
        }

        public async Task<List<UserNotificationDto>> GetMyNotificationsAsync(Guid userId)
        {
            var userNotifications = await _unitOfWork.UserNotificationRepository
                .GetAllAsync(
                    x => x.AppUserId == userId.ToString(),
                    "Notification",
                    "AppUser"
                );

            return _mapper.Map<List<UserNotificationDto>>(userNotifications);
        }

        public async Task MarkAsReadAsync(Guid notificationId, Guid userId)
        {
            var userNotification = await _unitOfWork.UserNotificationRepository
                .GetAsync(x =>
                    x.NotificationId == notificationId &&
                    x.AppUserId == userId.ToString());

            if (userNotification == null)
                throw new Exception($"Notification not found for user {userId}");

            if (!userNotification.IsRead)
            {
                userNotification.IsRead = true;
                userNotification.ReadAt = DateTime.UtcNow;
                await _unitOfWork.SaveAsync();
            }
        }
    }
}
