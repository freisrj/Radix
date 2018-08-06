using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Radix.Infra.ServiceClients.Options;

namespace Web.Configurations
{
    public static class AppSettingsOptionsConfigurations
    {
        private const string EnviromentLocalhost = "Localhost";
        private const string ApiStone = "ApiStone";
        private const string ApiCielo = "ApiCielo";

        public static WebHostBuilderContext ConfigAppSettingsFiles(this WebHostBuilderContext hostingContext, IConfigurationBuilder config)
        {      
            config.AddJsonFile($"appsettings.json", optional: false, reloadOnChange: true);

            config.AddEnvironmentVariables();

            return hostingContext;
        }

        public static IServiceCollection ConfigureAppSettingsOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();
            services.Configure<ApiStoneOptions>(options => configuration.GetSection(ApiStone).Bind(options));
            services.Configure<ApiCieloOptions>(options => configuration.GetSection(ApiCielo).Bind(options));

            return services;
        }
    }
}
