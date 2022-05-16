using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Core.Extensions
{
    public static class ConfigurationBuilderExtensions
    {
        public static void BuildConf(this IConfigurationBuilder builder, IHostEnvironment env)
        {
            builder.SetBasePath(env.ContentRootPath);
            builder.AddJsonFile("appsettings.json", false, true);
            if (env.IsDevelopment())
            {
                builder.AddJsonFile("appsettings.Development.json", false, true);
            }
        }
    }
}
