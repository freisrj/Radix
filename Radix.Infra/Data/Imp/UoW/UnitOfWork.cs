using Radix.Domain.Services.Contracts.Infra.Data.Contexts;
using Radix.Domain.Services.Contracts.Infra.Data.UoW;
using Radix.Infra.Data.Imp.Contexts;
using Radix.Infra.Data.Imp.UoW.Base;

namespace Radix.Infra.Data.Imp.UoW
{
    public class UnitOfWork : UoWBase<IDbContextRadix>, IUnitOfWork
    {
        public UnitOfWork(DbContextRadix context)  : base(context)
        {
        }
    }
}
