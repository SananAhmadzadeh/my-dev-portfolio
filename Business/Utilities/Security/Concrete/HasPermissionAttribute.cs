using Microsoft.AspNetCore.Authorization;

namespace Business.Utilities.Security.Concrete
{
    public class HasPermissionAttribute : AuthorizeAttribute
    {
        public HasPermissionAttribute(string permission)
        {
            Policy = "PERMISSION_" + permission;
        }
    }

}
