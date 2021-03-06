using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MSESoftware.JWTProject.Business.Containers.MicrosoftIOC;
using MSESoftware.JWTProject.Business.Interfaces;
using MSESoftware.JWTProject.Business.StringInfos;
using MSESoftware.JWTProject.WebAPI.CustomFilters;
using MSESoftware.JWTProject.WebAPI.InfrastructureSwagger;
using System;
using System.Text;

namespace MSESoftware.JWTProject.WebAPI
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
            //Bu attribute'u kullan�rken Generic object'in ne oldu�unu bilmedi�i i�in gelen objelerin t�r�n� kullanacak Generic'e e�itle diyoruz.
            services.AddScoped(typeof(ValidId<>));

            services.AddDependencies();

            services.AddAutoMapper(typeof(Startup));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt => 
            {
                opt.RequireHttpsMetadata = false;
                opt.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidIssuer = JWTInfo.Issuer,
                    ValidAudience = JWTInfo.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWTInfo.SecurityKey)),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero //Server'a bir zaman fark� koymamas� i�in
                };
            });

            services.AddControllers().AddFluentValidation();

            SwaggerServiceExtensions.AddSwaggerDocumentation(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IAppUserService appUserService, IAppUserRoleService appUserRoleService, IAppRoleService appRoleService)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //E�er bir hata gelirse, onu bizim Error Page'imize g�nder
            app.UseExceptionHandler("/Error");

            JWTIdentityInitializer.Seed(appUserService, appUserRoleService, appRoleService).Wait();

            SwaggerServiceExtensions.UseSwaggerDocumentation(app);

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
