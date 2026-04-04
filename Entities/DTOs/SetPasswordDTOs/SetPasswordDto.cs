using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs.SetPasswordDTOs
{
    public class SetPasswordDto:IDto
    {
        public string UserId { get; set; }
        public string NewPassword { get; set; }
        public string Token { get; set; }
    }
}
