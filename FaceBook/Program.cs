using BusinessLayer.Interfaces;
using BusinessLayer.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FaceBook
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //allow dependency injection for database
            builder.Services.AddDbContext<DataAccessLayer.Contexts.DataBase>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("conn")) ;
            });
            builder.Services.AddScoped<IDepartmentRepo,DepartmentRepo>(); // allow dependency inj for department repo
            

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
                pattern: "{controller=Department}/{action=getAll}/{id?}");

            app.Run();
        }
    }
}