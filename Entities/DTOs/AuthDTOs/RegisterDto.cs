using Core.Entities.Abstract;

namespace Entities.DTOs.Auth
{
    public class RegisterDto:IDto
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
