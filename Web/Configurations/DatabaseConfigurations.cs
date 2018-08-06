using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Radix.Infra.Data.Imp.Contexts;

namespace Web.Configurations
{
    public static class DatabaseConfigurations
    {
        private const string appSettingsConnStringContratacao = "Radix";

        public static IServiceCollection ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DbContextRadix>(options =>
            options.UseSqlServer(configuration.GetConnectionString(appSettingsConnStringContratacao),
                    x => x.MigrationsAssembly("Radix.Infra")));

            return services;
        }

        public static IApplicationBuilder UseMigrations(this IApplicationBuilder app, IHostingEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetService<DbContextRadix>().Database.Migrate();
                serviceScope.ServiceProvider.GetService<DbContextRadix>().EnsureSeeded();
            }

            return app;
        }
    }
}
