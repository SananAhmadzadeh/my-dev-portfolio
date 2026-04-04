using Core.Entities.Abstract;

namespace Core.Entities.Concrete.Auth
{
    public class Permission : IEntity
    {
        public int Id { get; set; }
        // ex: "TEACHER.CREATE", "STUDENT.READ"
        public string Code { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool IsDelegatable { get; set; } = true;
        public ICollection<AppUserPermission> AppUserPermissions { get; set; }
            = new List<AppUserPermission>();
        public ICollection<RolePermission> RolePermissions { get; set; }
            = new List<RolePermission>();
    }
}
