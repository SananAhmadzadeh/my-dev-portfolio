using Core.Entities.Abstract;

namespace Core.Entities.Concrete.Auth
{
    public class AppUserPermission: IEntity
    {
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int PermissionId { get; set; }
        public Permission Permission { get; set; }

        // KİM VERİB? (SuperAdmin, Admin, Teacher)
        public string? GrantedByUserId { get; set; }
    }
}
