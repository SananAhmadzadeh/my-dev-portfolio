using Microsoft.AspNetCore.Identity;

namespace Core.Entities.Concrete.Auth
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
        public DateTime? LastSeen { get; set; }
        public bool IsOnline { get; set; } = false;
        public ICollection<AppUserPermission> AppUserPermissions { get; set; } = new List<AppUserPermission>();
    }
}