using Business.Services.Abstract;
using Core.Entities.Concrete.Auth;
using Entities.DTOs.ForgotPasswordDTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

public class ResetPasswordManager : IResetPasswordService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IEmailService _emailService;
    private readonly IRedisOtpService _redisOtpService;

    public ResetPasswordManager(
        UserManager<AppUser> userManager,
        IEmailService emailService,
        IRedisOtpService redisOtpService)
    {
        _userManager = userManager;
        _emailService = emailService;
        _redisOtpService = redisOtpService;
    }

    public async Task<IActionResult> SendOtpToEmail(ForgotPasswordDto dto)
    {
        var user = await _userManager.FindByEmailAsync(dto.Email);
        if (user == null)
            return new BadRequestObjectResult("İstifadəçi tapılmadı");

        var otpCode = RandomNumberGenerator.GetInt32(100000, 999999).ToString("D6");

        await _redisOtpService.SaveOtpAsync(user.Id, otpCode);

        await _emailService.SendEmailAsync(
            user.Email,
            "Şifrə Bərpası",
            $"OTP kodunuz: {otpCode} (5 dəqiqə etibarlıdır)"
        );

        return new OkObjectResult("OTP göndərildi");
    }

    public async Task<IActionResult> VerifyOtp(VerifyOtpDto dto)
    {
        var storedOtp = await _redisOtpService.GetOtpAsync(dto.UserId);

        if (string.IsNullOrEmpty(storedOtp))
            return new BadRequestObjectResult("OTP tapılmadı və ya vaxtı bitib");

        if (storedOtp.Trim() != dto.Otp.Trim()) 
            return new BadRequestObjectResult("OTP yanlışdır");

        return new OkObjectResult("OTP doğrudur");
    }


    public async Task<IActionResult> ResetPasswordWithOtp(ResetPasswordWithOtpDto dto)
    {
        var storedOtp = await _redisOtpService.GetOtpAsync(dto.UserId);

        if (storedOtp == null)
            return new BadRequestObjectResult("OTP təsdiqlənməyib və ya müddəti bitib");

        var user = await _userManager.FindByIdAsync(dto.UserId);
        if (user == null)
            return new BadRequestObjectResult("İstifadəçi tapılmadı");

        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        var result = await _userManager.ResetPasswordAsync(user, token, dto.NewPassword);

        if (!result.Succeeded)
            return new BadRequestObjectResult(result.Errors.First().Description);

        await _redisOtpService.DeleteOtpAsync(dto.UserId);

        return new OkObjectResult("Şifrə uğurla yeniləndi");
    }
}
