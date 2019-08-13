using ZoEazy.Api.Data.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using ZoEazy.Api.Data.Repositories.Interfaces;

namespace ZoEazy.Api.Data
{
    public static class ServicesCollectionExtension
    {
        public static IServiceCollection AddInfrastructurServices(this IServiceCollection services)
        {
            services.AddSingleton<IStringLocalizerFactory, EFStringLocalizerFactory>();
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<IApplicationDataService, ApplicationDataService>();
            services.AddScoped<IUnitOfWork, HttpUnitOfWork>();
            services.AddTransient<ZoeazyDbContext>();
            services.AddTransient<ISeedData, SeedData>();
            services.AddTransient<IECustomerRepository, ECustomerRepository>();
            services.AddTransient<IOrdersRepository, OrdersRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();

            return services;
        }
    }
} 