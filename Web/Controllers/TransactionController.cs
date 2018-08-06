using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Radix.App.Messages;
using Radix.App.Services.Contracts;
using Radix.Domain.HttpServices;
using Radix.Domain.Models.Entities.Radix;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionAppService _transactionAppService;

        public TransactionController(ITransactionAppService transactionAppService)
        {
            _transactionAppService = transactionAppService;
        }

        [HttpPost("create/sale")]
        public async Task<HttpResult<Loja>> CreateSaleAsync([FromBody] MessageRequest request)
        {
            if (request == null)
                return new HttpResult<Loja>().Set(HttpStatusCode.BadRequest, $"Erro na requisição");
            return await _transactionAppService.CreateSaleAsync(request); ;
        }
        [HttpGet("search/transaction/{lojaId}")]
        public async Task<HttpResult<Loja>> SearchTransactionAsync(int lojaId)
        {
            return await _transactionAppService.SearchTransactionAsync(lojaId); 
        }
    }
}