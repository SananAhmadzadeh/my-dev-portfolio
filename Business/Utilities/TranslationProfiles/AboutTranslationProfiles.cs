//using AutoMapper;
//using Entities.TranslationConcrete;
//using Entities.TranslationDTOs.AboutTranslationDTOs;

//namespace Business.Utilities.TranslationProfiles
//{
//    public class AboutTranslationProfiles : Profile
//    {
//        public AboutTranslationProfiles()
//        {
//            CreateMap<AboutTranslation, GetAboutTranslationDTO>();

//            CreateMap<CreateAboutTranslationDTO, AboutTranslation>()
//                .AfterMap((src, dest) =>
//                {
//                    dest.Slug = $"{src.LanguageCode.ToLower()}/about";
//                }); 

//            CreateMap<UpdateAboutTranslationDTO, AboutTranslation>()
//            .ForMember(dest => dest.LanguageCode, opt => opt.Ignore())
//            .ForMember(dest => dest.Slug, opt => opt.Ignore())
//            .ForAllMembers(opt =>
//                opt.Condition((src, dest, srcMember) => srcMember != null));
//        }
//    }
//}
