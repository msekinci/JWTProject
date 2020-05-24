using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using MSESoftware.JWTProject.Business.Concrete;
using MSESoftware.JWTProject.Business.Interfaces;
using MSESoftware.JWTProject.Business.ValidationRules.FluentValidation;
using MSESoftware.JWTProject.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using MSESoftware.JWTProject.DataAccess.Interfaces;
using MSESoftware.JWTProject.Entities.DTOs.ProductDTOs;

namespace MSESoftware.JWTProject.Business.Containers.MicrosoftIOC
{
    public static class CustomExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));
            services.AddScoped(typeof(IGenericDal<>), typeof(EFGenericRepository<>));

            services.AddScoped<IProductDal, EFProductRepository>();
            services.AddScoped<IProductService, ProductManager>();

            services.AddScoped<IAppRoleDal, EFAppRoleRepository>();
            services.AddScoped<IAppRoleService, AppRoleManager>();

            services.AddScoped<IAppUserDal, EFAppUserRepository>();
            services.AddScoped<IAppUserService, AppUserManager>();

            services.AddScoped<IAppUserRoleDal, EFAppUserRoleRepository>();
            services.AddScoped<IAppUserRoleService, AppUserRoleManager>();

            services.AddTransient<IValidator<ProductAddDTO>, ProductAddDTOValidator>();
            services.AddTransient<IValidator<ProductUpdateDTO>, ProductUpdateDTOValidator>();
        }
    }
}
