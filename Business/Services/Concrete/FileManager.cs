using Business.Services.Abstract;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Services.Concrete
{
    public class FileManager : IFileService
    {
        private readonly string _rootPath;
        private readonly string[] _allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif",".pdf" };
        private const long _maxFileSize = 2 * 1024 * 1024; // 2MB

        public FileManager(IWebHostEnvironment env)
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
            var folderPath = Path.Combine(_rootPath, "Images", folderName);
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);
            var uniqueFileName = $"{Guid.NewGuid()}{extension}";
            var filePath = Path.Combine(folderPath, uniqueFileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return Path.Combine("Images", folderName, uniqueFileName).Replace("\\", "/");
        }
        public void Delete(string filePath)
        {
            var fullPath = Path.Combine(_rootPath, filePath.Replace("/", Path.DirectorySeparatorChar.ToString()));
            if (File.Exists(fullPath))
                File.Delete(fullPath);
        }
    }
}
