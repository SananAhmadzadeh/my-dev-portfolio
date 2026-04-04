using System.Collections.Concurrent;

public class OnlineUserManager : IOnlineUserService
{
    private static readonly ConcurrentDictionary<string, HashSet<string>> _users = new();

    public void UserConnected(string userId, string connectionId)
    {
        var connections = _users.GetOrAdd(userId, _ => new HashSet<string>());
        lock (connections) connections.Add(connectionId);
    }

    public void UserDisconnected(string userId, string connectionId)
    {
        if (_users.TryGetValue(userId, out var connections))
        {
            lock (connections)
            {
                connections.Remove(connectionId);
                if (connections.Count == 0)
                    _users.TryRemove(userId, out _);
            }
        }
    }

    public bool IsOnline(string userId) => _users.ContainsKey(userId);
    public int GetConnectionCount(string userId) => _users.TryGetValue(userId, out var c) ? c.Count : 0;
}