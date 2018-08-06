using Radix.Domain.Models.Entities.Radix;
using Radix.Domain.Services.Contracts.Infra.Data.Repositories;
using Radix.Infra.Data.Imp.Contexts;
using Radix.Infra.Data.Imp.Repositories.Base;

namespace Radix.Infra.Data.Imp.Repositories
{
    public class CartaoRepository : Repository<Cartao>, ICartaoRepository
    {
        public CartaoRepository(DbContextRadix context) : base(context) { }
    }
}
