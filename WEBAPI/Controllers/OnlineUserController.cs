using Core.Entities.Concrete.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IOnlineUserService _onlineUserService;
    private readonly UserManager<AppUser> _userManager;

    public UsersController(IOnlineUserService onlineUserService, UserManager<AppUser> userManager)
    {
        _onlineUserService = onlineUserService;
        _userManager = userManager;
    }

    [HttpGet("{userId}/status")]
    public async Task<IActionResult> GetStatus(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null) return NotFound();

        return Ok(new
        {
            isOnline = _onlineUserService.IsOnline(userId),
            lastSeen = user.LastSeen
        });
    }
}