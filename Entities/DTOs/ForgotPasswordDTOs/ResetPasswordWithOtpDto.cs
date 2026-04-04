using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs.ForgotPasswordDTOs
{
    public class ResetPasswordWithOtpDto : IDto
    {
        public string UserId { get; set; }
        public string NewPassword { get; set; }
    }
}
