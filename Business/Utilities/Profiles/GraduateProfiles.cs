using AutoMapper;
using Entities.Concrete;
using Entities.DTOs.GraduateDTOs;

namespace Business.Utilities.Profiles
{
    public class GraduateProfiles : Profile
    {
        public GraduateProfiles()
        {
            CreateMap<CreateGraduateDto, Graduate>();
            CreateMap<UpdateGraduateDto, Graduate>();
            CreateMap<Graduate, GetGraduateDto>();
            CreateMap<Graduate, GetAllGraduatesDto>();
            CreateMap<CreateGraduateDto, Graduate>();
        }
    }
}
