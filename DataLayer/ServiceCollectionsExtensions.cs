using Microsoft.Extensions.DependencyInjection;

namespace DataLayer
{
    public static class ServiceCollectionsExtensions
    {
        public static void AddDataLayers(this IServiceCollection services)
        {
            services.AddScoped<IGenericRepository, GenericRepository>();
        }
    }
}
