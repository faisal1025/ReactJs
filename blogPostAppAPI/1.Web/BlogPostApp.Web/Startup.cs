using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using blogPostAppAPI.DataAccess.ContextDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using blogPostAppAPI.Entities.UsersDomain.UOW;
using blogPostAppAPI.Entities.PostsDomain.UOW;
using AutoMapper;
using blogPostAppAPI.Entities.PostsDomain.Mapper;
using blogPostAppAPI.Entities.UsersDomain.Mapper;
using blogPostAppAPI.Entities.UsersDomain.AppServices;
using blogPostAppAPI.Entities.PostsDomain.AppServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BlogPostApp.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new PostMapperProfile());
                cfg.AddProfile(new UserMapperProfile());
            });
        }

        public IConfiguration Configuration { get; }
        private MapperConfiguration _mapperConfiguration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddCors();
            services.AddDbContext<blogPostDb>(options=>options.UseSqlServer(
                Configuration.GetConnectionString("LocConnectionString")), 
                ServiceLifetime.Singleton
                );

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).
                AddJwtBearer(options => {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "localhost",
                        ValidAudience = "localhost",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["jwtConfig:key"])),
                        ClockSkew = TimeSpan.Zero
                    };
                });

            services.AddSingleton<IMapper>(sp => _mapperConfiguration.CreateMapper());
            services.AddScoped<IUserUow, UserUow>();
            services.AddScoped<IPostUow, PostUow>();
            services.AddScoped<IUserAppService, UserAppService>();
            services.AddScoped<IPostAppService, PostAppService>();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors(m => m.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
