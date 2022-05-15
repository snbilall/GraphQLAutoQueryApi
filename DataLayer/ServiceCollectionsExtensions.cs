using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public static class ServiceCollectionsExtensions
    {
        public static void AddDataLayers(this IServiceCollection services, IConfiguration configuration)
        {
            var businessConnectionString = configuration.GetConnectionString("MainDb");

            services.AddDbContext<AppDbContext>(options =>
            {
                // Configure the context to use Microsoft SQL Server.
                options.UseSqlServer(businessConnectionString, sqlServerOptions =>
                {
                });
            }, ServiceLifetime.Scoped);

            services.AddScoped<IAppRepository, AppRepository>();
        }
    }
}
