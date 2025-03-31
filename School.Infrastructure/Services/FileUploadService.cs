using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using School.Application.Interfaces;

namespace School.Infrastructure.Services
{
    public class FileUploadService : IFileUploadService
    {
        private readonly IWebHostEnvironment _env;

        public FileUploadService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task<string> SaveFileAsync(IFormFile file, string folder)
        {
            var uploads = Path.Combine(_env.WebRootPath, folder);
            Directory.CreateDirectory(uploads);

            var filePath = Path.Combine(uploads, file.FileName);
            using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);

            return $"{folder}/{file.FileName}";
        }
    }
}
