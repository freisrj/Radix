using Radix.Domain.Services.Contracts.Infra.Data.UoW;

namespace Radix.Domain.Services.Imp.Entities.Base
{
    public class BaseService
    {
        protected IUnitOfWork _dbContext { get; private set; }

        public BaseService(IUnitOfWork dbContext)
        {
            this._dbContext = dbContext;
        }
    }
}
