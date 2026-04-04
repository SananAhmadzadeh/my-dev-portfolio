using System.Threading.Tasks;

public interface IRedisOtpService
{
    Task SaveOtpAsync(string userId, string otp);
    Task<string> GetOtpAsync(string userId);
    Task DeleteOtpAsync(string userId);
}
