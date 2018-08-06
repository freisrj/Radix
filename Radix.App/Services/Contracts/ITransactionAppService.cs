using Radix.App.Messages;
using Radix.Domain.HttpServices;
using Radix.Domain.Models.Entities.Radix;
using System.Threading.Tasks;

namespace Radix.App.Services.Contracts
{
    public interface ITransactionAppService
    {
        Task<HttpResult<Loja>> CreateSaleAsync(MessageRequest request);
        Task<HttpResult<Loja>> SearchTransactionAsync(int id);
    }
}
