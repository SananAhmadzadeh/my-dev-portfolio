using AutoMapper;
using Core.Entities.Concrete.Auth;
using Entities.Concrete;
using Entities.DTOs.StudentDTOs;
using Entities.DTOs.TeacherDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Utilities.Profiles
{
    public class TeacherProfiles : Profile
    {

        public TeacherProfiles()
        {
            CreateMap<CreateTeacherDto, Teacher>();
            CreateMap<UpdateTeacherDto, Teacher>();
            CreateMap<UpdateTeacherDto, AppUser>().ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
           .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
           .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
           .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber)).ReverseMap();
            CreateMap<Teacher, GetAllTeachersDto>().ForMember(d => d.FullName, o => o.MapFrom(s => s.AppUser.FullName))
            .ForMember(d => d.UserName, o => o.MapFrom(s => s.AppUser.UserName))
            .ForMember(d => d.Email, o => o.MapFrom(s => s.AppUser.Email))
            .ForMember(d => d.PhoneNumber, o => o.MapFrom(s => s.AppUser.PhoneNumber));
            CreateMap<Teacher, GetTeacherDto>()
                 .ForMember(d => d.FullName, o => o.MapFrom(s => s.AppUser.FullName))
            .ForMember(d => d.UserName, o => o.MapFrom(s => s.AppUser.UserName))
            .ForMember(d => d.Email, o => o.MapFrom(s => s.AppUser.Email))
            .ForMember(d => d.PhoneNumber, o => o.MapFrom(s => s.AppUser.PhoneNumber));
            CreateMap<CreateTeacherDto, AppUser>()
           .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
           .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
           .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
           .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber)).ReverseMap();

        }
    }
}