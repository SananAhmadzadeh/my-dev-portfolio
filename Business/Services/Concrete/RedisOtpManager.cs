using StackExchange.Redis;
using System;
using System.Threading.Tasks;

public class RedisOtpManager : IRedisOtpService
{
    private readonly IDatabase _db;

    public RedisOtpManager(IConnectionMultiplexer redis)
    {
        _db = redis.GetDatabase();
    }

    public async Task SaveOtpAsync(string userId, string otp)
    {
        await _db.StringSetAsync(
            $"otp:{userId}",
            otp,
            TimeSpan.FromMinutes(5)
        );
    }

    public async Task<string> GetOtpAsync(string userId)
    {
        return await _db.StringGetAsync($"otp:{userId}");
    }

    public async Task DeleteOtpAsync(string userId)
    {
        await _db.KeyDeleteAsync($"otp:{userId}");
    }
}
