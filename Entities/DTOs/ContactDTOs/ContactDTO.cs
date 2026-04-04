using Entities.Concrete;
using Entities.Enums.Contact;

namespace Entities.DTOs.ContactDTOs
{
    public class ContactDTO
    {
        public ContactType ContactType { get; set; }
        public ICollection<ContactItem> ContactItems { get; set; }
        public string AdditionalInfo { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
