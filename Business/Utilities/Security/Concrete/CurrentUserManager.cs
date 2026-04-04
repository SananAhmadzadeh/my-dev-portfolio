using Business.Utilities.Security.Abstract;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

public class CurrentUserManager : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserManager(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string UserId
    {
        get
        {
            var user = _httpContextAccessor.HttpContext?.User;

            if (user == null)
                return null;

            // IdentityUser Id claim-i: ClaimTypes.NameIdentifier
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
