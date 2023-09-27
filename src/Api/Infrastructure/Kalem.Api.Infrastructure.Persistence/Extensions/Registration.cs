using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Kalem.Api.Infrastructure.Persistence.Context;
using Kalem.Api.Infrastructure.Persistence.Repositories;
using Kalem.Api.Application.Interfaces.Repositories;

namespace Kalem.Api.Infrastructure.Persistence.Extensions
{
    public static class Registration
    {
        public static IServiceCollection AddInfrastructureRegistration(this IServiceCollection services, IConfiguration configuration)
        {
           

            services.AddDbContext<KalemContext>(options =>
            {
                var connStr = configuration["SqlServer"].ToString();
                options.UseSqlServer(connStr, opt =>
                {
                });
                
            });
            services.AddScoped<ISalesInvoiceRepository,SalesInvoiceRepository>();
            services.AddScoped<ISalesInvoiceItemRepository, SalesInvoiceItemRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IBrandRepository, BrandRepository>();
            

            return services;
        }
    }
}
