using Microsoft.EntityFrameworkCore;
using StudentMukesh.Web.Data;

namespace StudentMukesh.Web
{
    public class Program
    {

        // DI
        // A--(new B)- B -(new C)--- C--(new D)---- D
        // DI   A--(B)--B--(C)---C--(D)----D     // Entity Point new A, New B, New c, New D
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<ApplicationDbContext>(options=>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));




           // builder.Services.AddSingleton
           // builder.Services.AddTransient
           // builder.Services.AddScoped

            //DI (Design Pattern)----  IOC(Design Principle)

            //DI Types --- Constructor DI, Property Injection, Method Injection 
            // Development , Staging , Production

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //app.useException();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
// Client -(www.google.com/allbooks)>(request)---------m1(deligate)---m2----m3-----m4------Server
//Client -----------------------------------<(Response)------Server



//EFCore (Entity Framework Core)  1. Model First Approach(Code first), 2. DbFirst 
// ORM Object relational Mapper
// 1. Context File  (ORM)
// 2. Connection String
// Packages :  Microsoft. EntityFrameworkCore. SqlSever (EntityFrameworkCore) +  Tools 