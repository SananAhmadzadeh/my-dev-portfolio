using Core.Entities.Abstract;
using Core.Entities.Concrete.Auth;
using Entities.Common;

namespace Entities.Concrete
{
    public class Student : BaseEntity, IEntity
    {
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsCertificate { get; set; } = false;
        public string? CertificateUrl { get; set; }
        public Guid GroupId { get; set; }
        public Group Group { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
