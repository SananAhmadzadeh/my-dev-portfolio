namespace Core.Entities.DTOs
{
    public class SetUserPermissionDto
    {
        public string AppUserId { get; set; }
        public List<int> PermissionIds { get; set; }
    }

}
