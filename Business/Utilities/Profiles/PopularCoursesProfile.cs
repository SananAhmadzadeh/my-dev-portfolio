//using AutoMapper;
//using Entities.Concrete;
//using Entities.DTOs.HomePageDTOs.PopularCoursesSection;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Business.Utilities.Profiles
//{
//    public class PopularCoursesProfile : Profile
//    {
//        public PopularCoursesProfile()
//        {
//            CreateMap<Course, PopularCourseDto>()
//                .ForMember(dest => dest.Title,
//                           opt => opt.MapFrom(src => src.Name))
//                .ForMember(dest => dest.DurationInMonths,
//                           opt => opt.MapFrom(src =>
//                               (src.EndDate.Year - src.StartDate.Year) * 12 +
//                               (src.EndDate.Month - src.StartDate.Month)))
//                .ForMember(dest => dest.Rating,
//                           opt => opt.MapFrom(src => 0)); 
//        }
//    }
//}
