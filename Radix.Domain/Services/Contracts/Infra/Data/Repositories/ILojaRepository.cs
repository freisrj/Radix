using Radix.Domain.Models.Entities.Radix;
using Radix.Domain.Services.Contracts.Infra.Data.Repositories.Base;
using System.Threading.Tasks;

namespace Radix.Domain.Services.Contracts.Infra.Data.Repositories
{
    public interface ILojaRepository : IRepository<Loja>
    {
        Task<Loja> ObterLojaComCartao(int id);
        Task<Loja> ObterLojaComTransacoes(int id);
    }
}