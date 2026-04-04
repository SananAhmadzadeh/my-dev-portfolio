using Core.Entities.Abstract;

namespace Entities.DTOs.SkillDTOs
{
    public record CreateSkillDto
    (
        string Name
    ) : IDto;
}
