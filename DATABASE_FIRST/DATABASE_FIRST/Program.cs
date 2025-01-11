using DATABASE_FIRST.Models;
using Microsoft.EntityFrameworkCore;

namespace DATABASE_FIRST
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // pegar a conex�o do appsettings
            var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            // conectar contexto do banco a nosa aplica��o
            builder.Services.AddDbContext<MenuContext>(options => options.UseSqlServer(ConnectionString));

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
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
