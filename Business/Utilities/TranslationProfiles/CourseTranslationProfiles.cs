//using AutoMapper;
//using Entities.TranslationConcrete;
//using Entities.TranslationDTOs.CourseTranslationDTOs;

//namespace Business.Utilities.TranslationProfiles
//{
//    public class CourseTranslationProfiles : Profile
//    {
//        public CourseTranslationProfiles()
//        {
//            CreateMap<CourseTranslation, GetCourseTranslationDTO>();
//            CreateMap<CreateCourseTranslationDTO, CourseTranslation>();
//            CreateMap<UpdateCourseTranslationDTO, CourseTranslation>()
//                .ForAllMembers(opt => opt.Condition(
//                    (src, dest, srcMember) => srcMember != null));
//        }
//    }
//}
