using Microsoft.EntityFrameworkCore;
using StudentMukesh.Repository;
using StudentMukesh.Repository.Implementation;
using StudentMukesh.Repository.Implementations;
using StudentMukesh.Repository.Interface;
using StudentMukesh.Repository.Interfaces;

namespace StudentMukesh.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),b => b.MigrationsAssembly("StudentMukesh.UI")));
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IHospital, HospitalRepo>();
            builder.Services.AddScoped<IDoctor, DoctorRepo>();
            builder.Services.AddScoped<IMedicine, MedicineRepo>();
            builder.Services.AddScoped<IPatient, PatientRepo>();
            builder.Services.AddScoped<IUtilityService, UtilityService>();
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Doctors}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
