using Core.Entities.Abstract;
using Entities.Common;

namespace Entities.Concrete
{
    public class Statistics:BaseEntity, IEntity
    {
        public int GraduatedsCount { get; set; }
        public int CoursesCount { get; set; }
        public int GraduatesWorkingCount { get; set; }
        public int CompaniesPartnerCount { get; set; }

    }
}
