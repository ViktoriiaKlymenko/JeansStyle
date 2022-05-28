using JeansStyle.API;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JeansStyle
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddControllersWithViews();
            services.AddDatabase(Configuration);
            services.AddSwagger();
            services.AddRepositories();
            services.SetMapper();
            services.AddBllServices();
            services.AddCors();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStatusCodePages();
            app.UseRouting();
            app.UseCors(builder => builder
                                            .AllowAnyOrigin() // remove this in production
                                                              //.WithOrigins(Configuration["Urls:RedirectionUrls:FrontEndSite"]) // uncomment this in production
                                            .AllowAnyHeader()
                                            .AllowAnyMethod());
            app.UseAuthorization();
            app.UseStaticFiles();
            app.UseSwagger();
          

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllers();
            });
        }

    }
}