using Radix.Domain.Services.Contracts.Infra.Data.Contexts;
using Radix.Domain.Services.Contracts.Infra.Data.UoW.Base;

namespace Radix.Domain.Services.Contracts.Infra.Data.UoW
{
    public interface IUnitOfWork : IUoWBase<IDbContextRadix>
    {

    }
}
