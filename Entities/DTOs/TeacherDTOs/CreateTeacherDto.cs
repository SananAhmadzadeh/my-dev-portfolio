using Core.Entities.Abstract;
using Microsoft.AspNetCore.Http;

namespace Entities.DTOs.TeacherDTOs
{
    public class CreateTeacherDto : IDto
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Desc { get; set; }
        public string Position { get; set; }
        public IFormFile ImageUrl { get; set; }
        public Guid CourseId { get; set; }
    }
}
