using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using System_for_Sending_E_mail.Database;
using System_for_Sending_E_mail.Services.Abstracts;
using System_for_Sending_E_mail.Services.Concretes;

namespace System_for_Sending_E_mail
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews()
            .AddRazorRuntimeCompilation();

            builder.Services
               .AddDbContext<EMailDatabaseContext>(o =>
               {
                   var connectionString = "Server=localhost;Port=5432;Database=EmailSystemDataBase;User Id=postgres;Password=postgres;;";

                   o.UseNpgsql(connectionString);
               });
               

               
            
               

            var app = builder.Build();
            app.UseStaticFiles();
            app.MapControllerRoute("default", "{controller=Dashboard}/{action=Index}");
            app.Run();
        }
    }
}