using Core.Entities.Abstract;

namespace Entities.DTOs.GraduateDTOs
{
    public class GetGraduateDto : IDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public bool IsCertificate { get; set; }
        public string? CertificateUrl { get; set; }
        public Guid GroupId { get; set; }
    }
      
}
