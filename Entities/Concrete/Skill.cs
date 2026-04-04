using Core.Entities.Abstract;
using Entities.Common;

namespace Entities.Concrete
{
    public class Skill : BaseEntity, IEntity
    {
        public string Name { get; set; }
        public ICollection<VacancySkill> VacancySkills { get; set; } = new List<VacancySkill>();
    }
}
