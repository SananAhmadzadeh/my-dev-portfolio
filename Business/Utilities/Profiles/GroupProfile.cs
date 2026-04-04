using AutoMapper;
using Entities.Concrete;
using Entities.DTOs.GroupDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Utilities.Profiles
{
    public class GroupProfile : Profile
    {
        public GroupProfile()
        {
            CreateMap<Group, CreateGroupDto>().ReverseMap();
            CreateMap<Group, GetGroupDto>().ReverseMap();
            CreateMap<Group, GetAllGroupsDto>()
                       .ForMember(d => d.TeacherFullName,
                           o => o.MapFrom(s => s.Teacher.AppUser.FullName)); CreateMap<Group, UpdateGroupDto>().ReverseMap();


                           //        .ForMember(d => d.CourseName,
                           //o => o.MapFrom(s => s.Course.Name))
        }
    }
}
