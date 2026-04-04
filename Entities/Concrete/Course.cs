using Entities.Common;
using Core.Entities.Abstract;
//using Entities.TranslationConcrete;

namespace Entities.Concrete
{
    //public class Course : TranslatableEntity<CourseTranslation>, IEntity
    //{
    //    public string ImageUrl { get; set; }
    //    public decimal Price { get; set; } = 0;
    //    public int Time { get; set; }
    //    public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
    //}
    public class Course : BaseEntity, IEntity
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; }
        public decimal Price { get; set; } = 0;
        public int Time { get; set; }
        public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
    }
}