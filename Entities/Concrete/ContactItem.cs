using Core.Entities.Abstract;
using Entities.Common;

namespace Entities.Concrete
{
    public class ContactItem : BaseEntity, IEntity
    {
        public Guid ContactId { get; set; }
        public Contact Contact { get; set; }
        public string Item { get; set; }
    }
}
