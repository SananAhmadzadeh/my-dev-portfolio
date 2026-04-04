using Entities.Common;
using Core.Entities.Abstract;
//using Entities.TranslationConcrete;

namespace Entities.Concrete
{
    //public class Blog: TranslatableEntity<BlogTranslation>, IEntity
    //{
    //      public Guid TeacherId { get; set; }
    //      public Teacher Teacher { get; set; } = null!;
    //}
    public class Blog : BaseEntity, IEntity
    {
        public Guid TeacherId { get; set; }
        public Teacher Teacher { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
