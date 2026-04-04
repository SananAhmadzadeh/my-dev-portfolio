using Core.Entities.Concrete.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;

public class OnlineHub : Hub
{
    private readonly IOnlineUserService _onlineUserService;
    private readonly UserManager<AppUser> _userManager;

    public OnlineHub(IOnlineUserService onlineUserService, UserManager<AppUser> userManager)
    {
        _onlineUserService = onlineUserService;
        _userManager = userManager;
    }

    public override async Task OnConnectedAsync()
    {
        var userId = Context.UserIdentifier;
        if (string.IsNullOrEmpty(userId)) return;

        _onlineUserService.UserConnected(userId, Context.ConnectionId);

        var user = await _userManager.FindByIdAsync(userId);
        if (user != null)
        {
            user.IsOnline = true;      
            await _userManager.UpdateAsync(user);
        }

        await Clients.All.SendAsync("UserOnline", userId);

        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        var userId = Context.UserIdentifier;
        if (string.IsNullOrEmpty(userId)) return;

        _onlineUserService.UserDisconnected(userId, Context.ConnectionId);

        if (!_onlineUserService.IsOnline(userId))
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                user.IsOnline = false;
                user.LastSeen = DateTime.UtcNow;
                await _userManager.UpdateAsync(user);

                await Clients.All.SendAsync("UserOffline", userId, user.LastSeen);
            }
        }

        await base.OnDisconnectedAsync(exception);
    }
}