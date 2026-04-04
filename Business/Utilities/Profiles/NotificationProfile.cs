using AutoMapper;
using Entities.Concrete;
using Entities.DTOs.NotificationDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Utilities.Profiles
{
    internal class NotificationProfile:Profile
    {
        public NotificationProfile()
        {
            CreateMap<CreateNotificationDto, Notification>();

            CreateMap<UserNotification, UserNotificationDto>()
                .ForMember(dest => dest.Title,
                    opt => opt.MapFrom(src => src.Notification.Title))
                .ForMember(dest => dest.Message,
                    opt => opt.MapFrom(src =>
                        src.Notification.MessageTemplate
                            .Replace("{FullName}", src.AppUser.FullName)))
                .ForMember(dest => dest.CreatedAt,
                    opt => opt.MapFrom(src => src.Notification.CreatedAt));
        }
    }
}
