using Core.Entities.Abstract;
using Entities.Common;
using Entities.Enums.Vacancy;

namespace Entities.Concrete
{
    public class Vacancy : BaseEntity, IEntity
    {
        public string Title { get; set; }
        public string Category { get; set; }
        public string Location { get; set; }
        public WorkType WorkType { get; set; }
        public string EmploymentType { get; set; }
        public decimal SalaryMin { get; set; }
        public decimal SalaryMax { get; set; }
        public string Currency { get; set; }
        public bool IsNew { get; set; } = true;
        public ICollection<VacancySkill> VacancySkills { get; set; } = new List<VacancySkill>();
        public bool IsActive { get; set; } = true;
    }
}
