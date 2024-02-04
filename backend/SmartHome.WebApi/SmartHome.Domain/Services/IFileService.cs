using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Domain.Services
{
    public interface IFileService
    {
        Task<string> SaveImageAsync(IFormFile file, string targetFolder);
        bool IsImage(IFormFile file);
    }
}
