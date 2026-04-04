using Business.Services.Abstract;
using Entities.DTOs.ForgotPasswordDTOs;
using Entities.DTOs.SetPasswordDTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WEBAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ForgotPasswordController : ControllerBase
    {
        private readonly IResetPasswordService _resetPasswordService;

        public ForgotPasswordController(IResetPasswordService resetPasswordService)
        {
            _resetPasswordService = resetPasswordService;
        }

        [HttpPost]
        public async Task<IActionResult> SendOtp(ForgotPasswordDto dto)
        {
            return await _resetPasswordService.SendOtpToEmail(dto);
        }

        [HttpPost]
        public async Task<IActionResult> VerifyOtp( VerifyOtpDto dto)
        {
            return await _resetPasswordService.VerifyOtp(dto);
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword( ResetPasswordWithOtpDto dto)
        {
            return await _resetPasswordService.ResetPasswordWithOtp(dto);
        }
    }
}
