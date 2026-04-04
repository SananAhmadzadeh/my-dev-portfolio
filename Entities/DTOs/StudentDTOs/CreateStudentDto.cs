using Core.Entities.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Entities.DTOs.StudentDTOs;

public class CreateStudentDto : IDto
{
    public string FullName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    //public string Password { get; set; }
    public string Address { get; set; }
    public DateTime DateOfBirth { get; set; }
    public IFormFile? CertificateUrl { get; set; }
    public Guid GroupId { get; set; }
}