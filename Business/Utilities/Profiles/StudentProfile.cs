using AutoMapper;
using Core.Entities.Concrete.Auth;
using Entities.Concrete;
using Entities.DTOs.GraduateDTOs;
using Entities.DTOs.StudentDTOs;

namespace Business.Utilities.Profiles;

public class StudentProfile : Profile
{
    public StudentProfile()
    {
        CreateMap<CreateStudentDto, Student>();

        CreateMap<Student, GetStudentDto>();
        CreateMap<Student, GetAllStudentsDto>()
            .ForMember(d => d.FullName, o => o.MapFrom(s => s.AppUser.FullName))
            .ForMember(d => d.UserName, o => o.MapFrom(s => s.AppUser.UserName))
            .ForMember(d => d.Email, o => o.MapFrom(s => s.AppUser.Email))
            .ForMember(d => d.PhoneNumber, o => o.MapFrom(s => s.AppUser.PhoneNumber));
        CreateMap<Student, GetStudentDto>()
            .ForMember(d => d.FullName, o => o.MapFrom(s => s.AppUser.FullName))
            .ForMember(d => d.UserName, o => o.MapFrom(s => s.AppUser.UserName))
            .ForMember(d => d.Email, o => o.MapFrom(s => s.AppUser.Email))
            .ForMember(d => d.PhoneNumber, o => o.MapFrom(s => s.AppUser.PhoneNumber));
        CreateMap<Student, Graduate>();
        CreateMap<CreateStudentDto, AppUser>()
           .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
           .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
           .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
           .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber)).ReverseMap();
        CreateMap<UpdateStudentDto, AppUser>()
           .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
           .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
           .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
           .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber)).ReverseMap();
    }
}