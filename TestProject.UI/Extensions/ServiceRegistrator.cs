using TestProject.Application.Repositories;
using TestProject.Application.Services;

namespace TestProject.UI.Extensions
{
    public static class ServiceRegistrator
    {
        public static void RegisterCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
