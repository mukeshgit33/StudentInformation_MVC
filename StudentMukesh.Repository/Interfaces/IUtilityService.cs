using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMukesh.Repository.Interfaces
{
    public interface IUtilityService
    {
        Task<string> SaveImage(string ContainerName, IFormFile file);
        Task<string> EditImage(string ContainerName, IFormFile file, string DbPath);
        Task DeleteImage(string ContainerName, string DbPath);

    }
}
