using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MSESoftware.JWTProject.Business.Containers.MicrosoftIOC;
using MSESoftware.JWTProject.WebAPI.CustomFilters;

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
            services.AddControllers().AddFluentValidation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //E�er bir hata gelirse, onu bizim Error Page'imize g�nder
            app.UseExceptionHandler("/Error");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
