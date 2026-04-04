using Core.Entities.Abstract;
using Microsoft.AspNetCore.Identity;

namespace Core.Entities.Concrete.Auth
{
    public class RolePermission : IEntity
    {
        public string RoleId { get; set; }
        public IdentityRole Role { get; set; }
        public int PermissionId { get; set; }
        public Permission Permission { get; set; }
    }
}
