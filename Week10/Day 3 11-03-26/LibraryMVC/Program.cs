using LibraryMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<LibraryDBContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("LibraryDB")));

            var app = builder.Build();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
