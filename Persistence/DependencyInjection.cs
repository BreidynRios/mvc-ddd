using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;

namespace Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DBOrderContext>(o => o.UseSqlServer(configuration["DbConnectionString"]));
            services.AddScoped<IUnitOfWork>(o => o.GetRequiredService<DBOrderContext>());
            return services;
        }
    }
}