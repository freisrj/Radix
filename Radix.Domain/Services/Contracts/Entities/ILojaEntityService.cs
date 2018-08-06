using Radix.Domain.Models.Entities.Radix;
using System.Threading.Tasks;

namespace Radix.Domain.Services.Contracts.Entities
{
    public interface ILojaEntityService
    {
        Task<Loja> ObterLojaComCartao(int id);
        Task<Loja> ObterLojaComTransacoes(int id);
    }
}
