using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.Abstract
{
    public interface IEmailService
    {
        Task SendEmailAsync(string to, string subject, string body);
    }
}
