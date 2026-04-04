using AutoMapper;
using Entities.Concrete;
using Entities.DTOs.SkillDTOs;

namespace Business.Utilities.Profiles
{
    public class SkillProfile : Profile
    {
        public SkillProfile()
        {
            CreateMap<CreateSkillDto, Skill>();

            CreateMap<UpdateSkillDto, Skill>();

            CreateMap<Skill, GetSkillDto>()
                .ConstructUsing(s=> new GetSkillDto(
                    s.Name
                    ));

            CreateMap<Skill, GetAllSkillsDto>()
                .ConstructUsing(s=> new GetAllSkillsDto(
                   s.Id,
                   s.Name
                   ));
        }
    }
}
