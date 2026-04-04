using Core.Entities.Abstract;
using Entities.Common;
using Entities.Enums.Contact;

namespace Entities.Concrete
{
    public class Contact : BaseEntity, IEntity
    {
        public ContactType ContactType { get; set; }
        public ICollection<ContactItem> ContactItems { get; set; } = new List<ContactItem>();
        public string AdditionalInfo { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
