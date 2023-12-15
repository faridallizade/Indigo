using Indigo.DAL;
using Indigo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Indigo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();

            builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 1;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer("server = .; database=IndigoREDB; Trusted_connection=true; Integrated security=true; Encrypt=false"));

            var app = builder.Build();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });


            app.MapControllerRoute(
                name: "Home",
                pattern: "{controller=home}/{action=index}/{id?}");


            app.Run();
        }
    }
}