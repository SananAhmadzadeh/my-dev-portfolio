using AutoMapper;
using Entities.Concrete;
using Entities.DTOs.CourseDTOs;

namespace Business.Utilities.Profiles
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<CreateCourseDto, Course>();

            CreateMap<UpdateCourseDto, Course>();

            CreateMap<Course, GetCourseDto>();

            CreateMap<Course, GetAllCourseDto>();
        }
    }
}
