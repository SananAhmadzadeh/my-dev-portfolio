using AutoMapper;

namespace Business.Utilities.Profiles
{
    public class GraduateReviewProfile : Profile
    {
        public GraduateReviewProfile()
        {
            // CreateMap<GraduateReview, GraduateReviewDto>()
            //     .ForMember(dest => dest.FullName,
            //                opt => opt.MapFrom(src => $"{src.Graduate.FirstName} {src.Graduate.LastName}"))
            //     .ForMember(dest => dest.ProfileImageUrl,
            //                opt => opt.MapFrom(src => src.Graduate.ProfileImageUrl))
            //     .ForMember(dest => dest.JobTitle,
            //                opt => opt.MapFrom(src => src.Graduate.Position))
            //     .ForMember(dest => dest.Company,
            //                opt => opt.MapFrom(src => src.Graduate.Company));
        }
    }
}
