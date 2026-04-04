using Core.Entities.Abstract;
using Entities.Common;

namespace Entities.Concrete
{
    public class Graduate : BaseEntity, IEntity
    {
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsCertificate { get; set; } = false;
        public string? CertificateUrl { get; set; }
        public Guid GroupId { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
 
    }
}
