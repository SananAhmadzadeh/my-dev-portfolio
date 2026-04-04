using Core.Entities.Abstract;
using Entities.Common;

namespace Entities.Concrete
{
    public class VacancySkill : IEntity
    {
        public Guid VacancyId { get; set; }
        public Vacancy Vacancy { get; set; }
        public Guid SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}
