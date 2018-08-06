using Microsoft.Extensions.DependencyInjection;
using Radix.App.Services.Contracts;
using Radix.App.Services.Imp;
using Radix.Domain.Services.Contracts.Entities;
using Radix.Domain.Services.Contracts.Infra.Data.Contexts;
using Radix.Domain.Services.Contracts.Infra.Data.Repositories;
using Radix.Domain.Services.Contracts.Infra.Data.UoW;
using Radix.Domain.Services.Contracts.ServiceClient;
using Radix.Domain.Services.Contracts.Tasks;
using Radix.Domain.Services.Imp.Entities;
using Radix.Domain.Services.Imp.Tasks;
using Radix.Infra.Data.Imp.Contexts;
using Radix.Infra.Data.Imp.Repositories;
using Radix.Infra.Data.Imp.UoW;
using Radix.Infra.ServiceClients.Services.Stone;

namespace Radix.Infra.Cross.DI
{
    public class DIFactory
    {
        public static void ConfigureDI(IServiceCollection services)
        {
            ConfigureDataAccess(services);
            ConfigureApplicationServices(services);
            ConfigureDomainServices(services);
            ConfigureServiceClients(services);
        }

        private static void ConfigureDataAccess(IServiceCollection services)
        {
            services.AddScoped<IDbContextRadix, DbContextRadix>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ILojaRepository, LojaRepository>();
            services.AddScoped<ICartaoRepository, CartaoRepository>();
        }

        private static void ConfigureApplicationServices(IServiceCollection services)
        {
            services.AddScoped<ITransactionAppService, TransactionAppService>();
        }

        private static void ConfigureDomainServices(IServiceCollection services)
        {
            services.AddScoped<ITransactionServiceTask, TransactionServiceTask>();
            services.AddScoped<ILojaEntityService, LojaEntityService>();
        }

        private static void ConfigureServiceClients(IServiceCollection services)
        {
            services.AddScoped<IServiceClient, ServiceClient>();
        }
    }
}
