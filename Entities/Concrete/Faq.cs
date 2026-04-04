using Core.Entities.Abstract;
using Entities.Common;

namespace Entities.Concrete
{
    public class Faq : BaseEntity, IEntity
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public int Order { get; set; }
        public bool IsActive { get; set; }
    }
}
