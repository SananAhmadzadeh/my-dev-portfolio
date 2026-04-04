using AutoMapper;
using Entities.Concrete;
using Entities.DTOs.GraduateDTOs;

namespace Business.Utilities.Profiles
{
    public class GraduateProfile : Profile
    {
        public GraduateProfile()
        {
            CreateMap<CreateGraduateDto, Graduate>().ReverseMap();
            CreateMap<UpdateGraduateDto, Graduate>().ReverseMap();
            CreateMap<Graduate, GetGraduateDto>().ReverseMap();
            CreateMap<Graduate, GetAllGraduatesDto>().ReverseMap();
        }
    }
}
