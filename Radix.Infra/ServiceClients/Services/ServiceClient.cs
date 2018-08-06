using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Radix.Domain.Models.Entities.Cielo.Message;
using Radix.Domain.Models.Entities.Messages;
using Radix.Domain.Services.Contracts.ServiceClient;
using Radix.Infra.ServiceClients.Options;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Radix.Infra.ServiceClients.Services.Stone
{
    public class ServiceClient : IServiceClient
    {
        private readonly IOptions<ApiStoneOptions> _apiStoneOptions;
        private readonly IOptions<ApiCieloOptions> _apiCieloOptions;
        private static readonly HttpClient client = new HttpClient();
        

        public ServiceClient(IOptions<ApiStoneOptions> apiStoneOptions, IOptions<ApiCieloOptions> apiCieloOptions)
        {
            _apiStoneOptions = apiStoneOptions;
            _apiCieloOptions = apiCieloOptions;
        }

        public async Task<SaleResponse> TransacitonAsync(SaleRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("MerchantKey", _apiStoneOptions.Value.MerchantKey);

            var response = await client.PostAsync(_apiStoneOptions.Value.Url, content);
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<SaleResponse>(responseString);
        }

        public async Task<CieloResponse> TransacitonAsync(CieloRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("MerchantKey", _apiCieloOptions.Value.MerchantKey);
            client.DefaultRequestHeaders.Add("MerchantId", _apiCieloOptions.Value.MerchantId);

            var retorno = await client.PostAsync(_apiCieloOptions.Value.Url, content);
            var responseString = await retorno.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CieloResponse>(responseString);
        }
    }
}
