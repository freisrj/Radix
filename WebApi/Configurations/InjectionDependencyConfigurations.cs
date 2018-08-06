using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
//using Radix.Infra.Cross.DI;

namespace WebApi.Configurations
{
    public static class InjectionDependencyConfigurations
    {
        public static IServiceCollection ConfigureDI(this IServiceCollection services, IConfiguration configuration)
        {
           // DIFactory.ConfigureDI(services);

            return services;
        }
    }
}
