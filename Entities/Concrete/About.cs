using Core.Entities.Abstract;
using Entities.Common;
//using Entities.TranslationConcrete;

namespace Entities.Concrete
{
    //public class About: TranslatableEntity<AboutTranslation>,IEntity
    //{
    //    public int Year{ get; set; }    
    //}
    public class About : BaseEntity, IEntity
    {
        public int Year { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
