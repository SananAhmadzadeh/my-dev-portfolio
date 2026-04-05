//using AutoMapper;
//using Entities.TranslationConcrete;
//using Entities.TranslationDTOs.BlogTranslationDTOs;

//namespace Business.Utilities.TranslationProfiles
//{
//    public class BlogTranslationProfiles : Profile
//    {
//        public BlogTranslationProfiles()
//        {
//            CreateMap<BlogTranslation, GetBlogTranslationDTO>();

//            CreateMap<CreateBlogTranslationDTO, BlogTranslation>()
//                .AfterMap((src, dest) =>
//                {
//                    dest.Slug = $"{src.LanguageCode.ToLower()}/blog";
//                });

//            CreateMap<UpdateBlogTranslationDTO, BlogTranslation>()
//                .ForMember(dest => dest.LanguageCode, opt => opt.Ignore())
//                .ForMember(dest => dest.Slug, opt => opt.Ignore())
//                .ForAllMembers(opt => 
//                  opt.Condition((src, dest, srcMember) => srcMember != null));
//        }
//    }
//}
