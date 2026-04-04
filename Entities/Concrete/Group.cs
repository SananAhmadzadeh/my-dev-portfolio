using Core.Entities.Abstract;
using Entities.Common;

namespace Entities.Concrete
{
    public class Group : BaseEntity, IEntity
    {
        public string Name { get; set; }
        public Guid? CourseId { get; set; }
        public Course Course { get; set; }
        public Guid? TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
