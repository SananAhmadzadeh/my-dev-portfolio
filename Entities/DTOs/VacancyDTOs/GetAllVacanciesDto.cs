using Core.Entities.Abstract;
using Entities.Enums.Vacancy;

namespace Entities.DTOs.VacancyDTOs
{
    public record GetAllVacanciesDto
    (
         Guid Id,
         string Title,
         string Category,
         string Location,
         WorkType WorkType,
         string EmploymentType,
         decimal SalaryMin,
         decimal SalaryMax,
         string Currency,
         bool IsNew,
         bool IsActive,
         List<string>? SkillNames = null
    ) : IDto;
}
