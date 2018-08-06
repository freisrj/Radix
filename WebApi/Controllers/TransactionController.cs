using Microsoft.AspNetCore.Mvc;
using Radix.App.Messages;
using System.Threading.Tasks;
 
namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        [HttpPost("create/sale")]
        public async Task<CreateSaleMessageResponse> CreateSaleAsync([FromBody] CreateSaleMessageRequest request)
        {
            return new CreateSaleMessageResponse();
        }
    }
}