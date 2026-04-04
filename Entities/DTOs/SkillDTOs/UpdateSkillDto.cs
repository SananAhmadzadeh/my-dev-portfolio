using Core.Entities.Abstract;

namespace Entities.DTOs.SkillDTOs
{
    public record UpdateSkillDto
    (
        string Name
    ) : IDto;
}
