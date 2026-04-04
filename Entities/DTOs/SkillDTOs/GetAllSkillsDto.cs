using Core.Entities.Abstract;

namespace Entities.DTOs.SkillDTOs
{
    public record GetAllSkillsDto
    (
       Guid Id,
       string Name
    ) : IDto;
}
