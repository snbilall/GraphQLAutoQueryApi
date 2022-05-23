using Microsoft.Extensions.DependencyInjection;

namespace Business
{
    public static class ServiceCollectionExtensions
    {
        public static void AddGxraphQlServices(this IServiceCollection services)
        {
            //services
            //.AddGraphQL(
            //    (options, provider) =>
            //    {
            //        // Load GraphQL Server configurations
            //        var graphQLOptions = Configuration
            //            .GetSection("GraphQL")
            //            .Get<GraphQLOptions>();
            //        options.ComplexityConfiguration = graphQLOptions.ComplexityConfiguration;
            //        options.EnableMetrics = graphQLOptions.EnableMetrics;
            //        // Log errors
            //        var logger = provider.GetRequiredService<ILogger<Startup>>();
            //        options.UnhandledExceptionDelegate = ctx =>
            //            logger.LogError("{Error} occurred", ctx.OriginalException.Message);
            //    })
            //// Adds all graph types in the current assembly with a singleton lifetime.
            //.AddGraphTypes()
            //// Add GraphQL data loader to reduce the number of calls to our repository. https://graphql-dotnet.github.io/docs/guides/dataloader/
            //.AddDataLoader()
            //.AddSystemTextJson();
        }
    }
}
