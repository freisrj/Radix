using Radix.Domain.Models.Entities.Cielo.Message;
using Radix.Domain.Models.Entities.Messages;
using System.Threading.Tasks;

namespace Radix.Domain.Services.Contracts.ServiceClient
{
    public interface IServiceClient
    {
        Task<SaleResponse> TransacitonAsync(SaleRequest request);
        Task<CieloResponse> TransacitonAsync(CieloRequest request);
    }
}
