using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.Interfaces
{
    public interface IFileUploadService
    {
        Task<string> SaveFileAsync(IFormFile file, string folder);
    }

}
