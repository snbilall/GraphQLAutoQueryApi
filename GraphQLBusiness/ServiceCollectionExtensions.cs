using HotChocolate;
using Microsoft.Extensions.DependencyInjection;
using GraphQLBusiness;

namespace Business
{
    public static class ServiceCollectionExtensions
    {
        public static void AddGraphQlServices(this IServiceCollection services)
        {
            services.AddGraphQLServer()
                .AddQueryType<Query>();
        }
    }
}
