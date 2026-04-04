using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs.ForgotPasswordDTOs
{
    public class ForgotPasswordDto:IDto
    {
        public string Email { get; set; }
    }
}
