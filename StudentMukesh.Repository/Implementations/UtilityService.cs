using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using StudentMukesh.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMukesh.Repository.Implementations
{

    // https://localhost:7099/ContainerName/hgjuio-dfdghu-gfgfj.jpg
    public class UtilityService : IUtilityService
    {
        private IWebHostEnvironment _env;
        private IHttpContextAccessor _contextAccessor;

        public UtilityService(IWebHostEnvironment env, IHttpContextAccessor contextAccessor)
        {
            _env = env;
            _contextAccessor = contextAccessor;
        }

        public Task DeleteImage(string ContainerName, string DbPath)
        {
           if(DbPath==null)
            {
                return Task.CompletedTask;
            }
           var filename =  Path.GetFileName(DbPath);
            var filePath = Path.Combine(_env.WebRootPath, ContainerName, filename);
            if(File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            return Task.CompletedTask;  

        }

        public async Task<string> EditImage(string ContainerName, IFormFile file, string DbPath)
        {
            await DeleteImage(ContainerName, DbPath);
            return await SaveImage(ContainerName, file);

        }

        public async Task<string> SaveImage(string ContainerName, IFormFile file)
        {
            var extension =  Path.GetExtension(file.FileName);
            var filename = $"{Guid.NewGuid()}{extension}";
            var folder = Path.Combine(_env.WebRootPath, ContainerName);
            if(!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            string filePath =  Path.Combine(folder, filename);
            using(var memoryStreem =  new MemoryStream())
            {
                await file.CopyToAsync(memoryStreem);
                var content  = memoryStreem.ToArray();
                await File.WriteAllBytesAsync(filePath, content);
            }
            //https://localhost:7009\\ContainerName\\jksfsdjfjk-=-dfdbfhds.jpg

            var basePath = $"{_contextAccessor.HttpContext.Request.Scheme}://{_contextAccessor.HttpContext.Request.Host}";
            var dbPath = Path.Combine(basePath, ContainerName, filename).Replace("\\","/");
            return dbPath;



        }
    }
}
// wwwroot\\DoctorImage\\djg-dgdgb-fdgdfg.jpg
