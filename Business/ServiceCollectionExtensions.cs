using Business.UsualQueryService;
using Microsoft.Extensions.DependencyInjection;

namespace Business
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUsualQueryService, UsualQueryService.UsualQueryService>();
        }
    }
}
