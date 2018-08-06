using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Radix.Domain.Models.Entities.Radix;
using Radix.Domain.Services.Contracts.Infra.Data.Repositories;
using Radix.Infra.Data.Imp.Contexts;
using Radix.Infra.Data.Imp.Repositories.Base;

namespace Radix.Infra.Data.Imp.Repositories
{
    public class LojaRepository : Repository<Loja>, ILojaRepository
    {
        public LojaRepository(DbContextRadix context) : base(context) { }

        public async Task<Loja> ObterLojaComCartao(int id) => await Context.Loja.Include(l => l.Cartoes).FirstOrDefaultAsync(l => l.Id == id);
        public async Task<Loja> ObterLojaComTransacoes(int id) => await Context.Loja
            .Include(l => l.RegistroTransacaoCielo)
            .Include(l => l.RegistroTransacaoStone)
            .FirstOrDefaultAsync(l => l.Id == id);

    }
}
