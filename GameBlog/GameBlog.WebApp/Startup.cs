using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GameBlog.Models;
using GameBlog.DAL.Entities;
using System.Reflection;

namespace GameBlog.WebApp
{
    public class Startup
    {
        public Startup(IWebHostEnvironment hostingEnvironment, IWebHostEnvironment env)
        {
            var appAssembly = Assembly.Load(new AssemblyName(hostingEnvironment.ApplicationName));
            ConfigurationBuilder configBuilder = new ConfigurationBuilder();
            configBuilder
                .SetBasePath(hostingEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .AddUserSecrets(appAssembly, optional: true);
            IConfiguration configRoot = configBuilder.Build();
            Configuration = configRoot;
            Env = env;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Env { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<GameBlogDbContext>(options =>
            options.UseNpgsql(
                Configuration.GetConnectionString("PostgresConnection"),
                options =>
                {
                    options.EnableRetryOnFailure();
                    options.MigrationsAssembly("GameBlog.DAL");
                }
                ));

            services.AddIdentity<User, Role>(cfg =>
            {
                cfg.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<GameBlogDbContext>()
                ;

            services.AddAuthentication()
                .AddFacebook(facebookOptions =>
                    {
                        IConfigurationSection facebookAuthNSection =
                            Configuration.GetSection("Authentication:Facebook");

                        facebookOptions.AppId = facebookAuthNSection["AppId"];
                        facebookOptions.AppSecret = facebookAuthNSection["AppSecret"];
                    })
                .AddGoogle(googleOptions =>
                    {
                        IConfigurationSection googleAuthNSection =
                            Configuration.GetSection("Authentication:Google");

                        googleOptions.ClientId = googleAuthNSection["ClientId"];
                        googleOptions.ClientSecret = googleAuthNSection["ClientSecret"];
                    })
                .AddSteam(steamOptions =>
                {
                    IConfigurationSection steamAuthNSection =
                        Configuration.GetSection("Authentication:Google");

                    steamOptions.ApplicationKey = steamAuthNSection["ApplicationKey"];
                });

            services.AddScoped<RoleManager<Role>>();

            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
