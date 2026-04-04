using Core.Entities.Abstract;

namespace Entities.DTOs.StudentDTOs;

public class GetAllStudentsDto : IDto
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Address { get; set; }
    public bool IsCertificate { get; set; }
    public string CertificateUrl { get; set; }
}
