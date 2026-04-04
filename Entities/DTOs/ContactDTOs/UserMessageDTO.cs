using Entities.Enums.Contact;

namespace Entities.DTOs.ContactDTOs
{
    public class UserMessageDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public Topic Topic { get; set; }
        public string Message { get; set; }
    }
}
