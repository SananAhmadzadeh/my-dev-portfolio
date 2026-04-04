using Entities.DTOs.ForgotPasswordDTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.Abstract
{
    public interface IResetPasswordService
    {
        Task<IActionResult> SendOtpToEmail(ForgotPasswordDto dto);
        Task<IActionResult> VerifyOtp(VerifyOtpDto dto);

        Task<IActionResult> ResetPasswordWithOtp(ResetPasswordWithOtpDto dto);
    }
}
