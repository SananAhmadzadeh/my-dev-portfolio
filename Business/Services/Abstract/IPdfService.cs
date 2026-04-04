using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.Abstract
{
    public interface IPdfService
    {
        Task<string> UploadAsync(IFormFile file, string folderName);
        void Delete(string filePath);
    }
}
