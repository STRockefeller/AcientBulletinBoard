using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.Cookies;
using AcientBulletinBoard.Middlewares;
using AcientBulletinBoard.DataModels;
using LinqToDB.AspNet;
using LinqToDB.AspNet.Logging;
using AcientBulletinBoard.Hubs;

namespace AcientBulletinBoard
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddMvc();
            services.AddSignalR();
            services.AddSingleton<AuthenticationMiddleware>();
            services.AddSingleton<CommentSubmitMiddleware>();
            services.AddLinqToDbContext<AppDataConnection>((provider, options) =>
            {
                options
                .UseSQLite(Configuration.GetConnectionString("Default"))
                .UseDefaultLogging(provider);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthenticationMiddleware();
            app.UseCommentSubmitMiddleware();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapHub < ChatRoomHub > ("/ChatRoomHub");
            });
        }
    }
}
