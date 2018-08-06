using System;
using System.Linq;
using System.Threading.Tasks;
using Radix.App.Mapper;
using Radix.App.Messages;
using Radix.App.Services.Contracts;
using Radix.Domain.HttpServices;
using Radix.Domain.Models.Entities.Radix;
using Radix.Domain.Models.EnumTypes;
using Radix.Domain.Services.Contracts.Entities;
using Radix.Domain.Services.Contracts.Tasks;

namespace Radix.App.Services.Imp
{
    public class TransactionAppService : ITransactionAppService
    {
        private readonly ITransactionServiceTask _transactionServiceTask;
        private readonly ILojaEntityService _lojaEntityService;

        public TransactionAppService(ITransactionServiceTask transactionServiceTask, ILojaEntityService lojaEntityService)
        {
            _transactionServiceTask = transactionServiceTask;
            _lojaEntityService = lojaEntityService;
        }

        public async Task<HttpResult<Loja>> CreateSaleAsync(MessageRequest request)
        {
            HttpResult<Loja> response = new HttpResult<Loja>();

            if (request == null) return response.SetRequestMessage(request);
            if (!_transactionServiceTask.ValidadarDadosDeEntrada(response, request.BandeiraCartao)) return response;

            var orderId = $"{DateTime.Now.Year.ToString()}{DateTime.Now.Month.ToString()}{new Random().Next(10000, 99999)}";
            var loja = await _transactionServiceTask.ObterLojaComCartao(request.LojaId);

            if (!loja.Valid) return loja;

            var adquirente = loja.Response.Cartoes.FirstOrDefault(b => b.Bandeira == request.BandeiraCartao)?.Adquirente;
            if(adquirente == null) return response.SetHttpStatusToBadRequest("Adquirente não vinculado a loja");

            // * Implementar antifraude

            if (adquirente == AdquirenteEnum.Cielo)
                return await _transactionServiceTask.CreateTransactionCieloAsync(MapToModelCielo.MapToModel(request, orderId), request.LojaId);
            else
                return await _transactionServiceTask.CreateTransactionStoneAsync(MapToModelStone.MapToModel(request, orderId), request.LojaId);
        }

        public async Task<HttpResult<Loja>> SearchTransactionAsync(int id)
        {
            HttpResult<Loja> response = new HttpResult<Loja>();

            var loja = await _lojaEntityService.ObterLojaComTransacoes(id);
            if (loja == null) return response.SetHttpStatusToBadRequest("Loja não existe ou não cadastrada");

            response.Response = loja;
            return response;
        }
    }
}
