using Business.Services.Abstract;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Services.Concrete
{
    public class PdfManager:IPdfService
    {
        private readonly string _rootPath;
        private readonly string[] _allowedExtensions = { ".pdf" };
        private const long _maxFileSize = 2 * 2048 * 2048; // 2MB

        public PdfManager(IWebHostEnvironment env)
        {
            _rootPath = env.WebRootPath;
        }

        public async Task<string> UploadAsync(IFormFile file, string folderName)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("File is null or empty");
            if (file.Length > _maxFileSize)
                throw new ArgumentException("File size exceeds the limit");
            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (!_allowedExtensions.Contains(extension))
                throw new ArgumentException("Invalid file type");
            var folderPath = Path.Combine(_rootPath, "PDF", folderName);
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);
            var uniqueFileName = $"{Guid.NewGuid()}{extension}";
            var filePath = Path.Combine(folderPath, uniqueFileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return Path.Combine("PDF", folderName, uniqueFileName).Replace("\\", "/");
        }
        public void Delete(string filePath)
        {
            var fullPath = Path.Combine(_rootPath, filePath.Replace("/", Path.DirectorySeparatorChar.ToString()));
            if (File.Exists(fullPath))
                File.Delete(fullPath);
        }
    }
}

