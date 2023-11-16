using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp;
using SmartHome.Domain.Services;
using System;
using System.IO;
using System.Threading.Tasks;

namespace SmartHome.Application.Services
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _env;

        public FileService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task<string> SaveImageAsync(IFormFile file, string targetFolder)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("File is required.");
            }

            if (!IsImage(file))
            {
                throw new ArgumentException("Invalid image format.");
            }

            var fileExtension = Path.GetExtension(file.FileName);
            var uniqueFileName = Guid.NewGuid().ToString() + fileExtension;

            // Get the wwwroot path using _env.ContentRootPath
            var wwwrootPath = Path.Combine(_env.ContentRootPath, "wwwroot");

            // Combine the path to the wwwroot folder with the target folder
            var targetFolderPath = Path.Combine(wwwrootPath, targetFolder);

            // Create the target folder if it doesn't exist
            if (!Directory.Exists(targetFolderPath))
            {
                Directory.CreateDirectory(targetFolderPath);
            }

            // Combine the path to the target folder with the unique filename
            var filePath = Path.Combine(targetFolderPath, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Path.Combine(targetFolder, uniqueFileName);
        }


        public bool IsImage(IFormFile file)
        {
            try
            {
                using (var image = Image.Load(file.OpenReadStream()))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
