using Radix.Domain.HttpServices;
using Radix.Domain.Models.Entities.Cielo.Message;
using Radix.Domain.Models.Entities.Messages;
using Radix.Domain.Models.Entities.Radix;
using Radix.Domain.Models.EnumTypes;
using System.Threading.Tasks;

namespace Radix.Domain.Services.Contracts.Tasks
{
    public interface ITransactionServiceTask
    {
        //Task<AdquirenteEnum> ObterAdquirinte(int lojaId, CreditCardBrandEnum bandeira);
        Task<HttpResult<Loja>> CreateTransactionCieloAsync(CieloRequest request, int lojaId);
        Task<HttpResult<Loja>> CreateTransactionStoneAsync(SaleRequest request, int lojaId);
        bool ValidadarDadosDeEntrada(HttpResult<Loja> response, CreditCardBrandEnum bandeira);
        Task<HttpResult<Loja>> ObterLojaComCartao(int lojaId);
    }
}
