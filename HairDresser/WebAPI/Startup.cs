using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DbContexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using WebAPI.Configurations;
using Application.Services;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using WebAPI.Authentication;

namespace WebAPI
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
            services.AddCors(options =>
                    options.AddPolicy("CorsPolicy", p => p.WithOrigins("http://localhost:4200")
                                                             .AllowAnyMethod()
                                                             .AllowAnyHeader()
                                                             .AllowCredentials()));

            services.AddDefaultIdentity<IdentityUser>(o =>
            {
                o.Password.RequireDigit = true;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 6;
                o.Password.RequiredUniqueChars = 0;
                o.User.RequireUniqueEmail = true;
            }).AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<HairDresserDbContext>()
            .AddDefaultTokenProviders();

            services.AddAutoMapper(typeof(HairDresserProfile));

            services.ConfigureAuthentication(Configuration);

            services.AddControllers();

            services.AddScoped<IJWTFactory, JWTFactory>();
            services.AddScoped<ISalonService, SalonService>();
            services.AddScoped<IClientService, ClientService>();

            services.AddDbContext<HairDresserDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
                              IWebHostEnvironment env,
                              ILoggerFactory loggerFactory,
                              RoleManager<IdentityRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            HairDresserRoles.SeedRoles(roleManager).Wait();

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseRouting();

            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
