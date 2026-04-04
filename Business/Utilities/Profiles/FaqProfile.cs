using AutoMapper;
using Entities.Concrete;
using Entities.DTOs.HomePageDTOs.FaqSection;

namespace Business.Utilities.Profiles
{
    public class FaqProfile : Profile
    {
        public FaqProfile()
        {
            CreateMap<Faq, FaqItemDto>();
        }
    }
}
