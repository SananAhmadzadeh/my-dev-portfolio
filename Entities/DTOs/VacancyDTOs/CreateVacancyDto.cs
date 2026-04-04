using Core.Entities.Abstract;
using Entities.Enums.Vacancy;

namespace Entities.DTOs.VacancyDTOs
{
    public record CreateVacancyDto
    (
        string Title,
        string Category,
        string Location,
        WorkType WorkType,
        string EmploymentType,
        decimal SalaryMin,
        decimal SalaryMax,
        string Currency,
        List<Guid>? SkillIds = null
    ) : IDto;
}
