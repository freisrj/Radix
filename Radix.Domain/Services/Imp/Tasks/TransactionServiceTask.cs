using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Radix.Domain.HttpServices;
using Radix.Domain.Models.Entities.Cielo.Message;
using Radix.Domain.Models.Entities.Messages;
using Radix.Domain.Models.Entities.Radix;
using Radix.Domain.Models.EnumTypes;
using Radix.Domain.Services.Contracts.Entities;
using Radix.Domain.Services.Contracts.Infra.Data.UoW;
using Radix.Domain.Services.Contracts.ServiceClient;
using Radix.Domain.Services.Contracts.Tasks;
using Radix.Domain.Services.Imp.Entities.Base;

namespace Radix.Domain.Services.Imp.Tasks
{
    public class TransactionServiceTask : BaseService, ITransactionServiceTask
    {
        private readonly IServiceClient _serviceClient;
        private readonly ILojaEntityService _lojaEntityService;
        private string[] sucessoCielo = new string[] { "4", "6" };

        public TransactionServiceTask(IUnitOfWork unitOfWork,
            IServiceClient serviceClient,
            ILojaEntityService lojaEntityService) : base(unitOfWork)
        {
            _serviceClient = serviceClient;
            _lojaEntityService = lojaEntityService;
        }

        public async Task<HttpResult<Loja>> CreateTransactionStoneAsync(SaleRequest request, int lojaId)
        {
            var retorno = new HttpResult<Loja>();
            var response = await _serviceClient.TransacitonAsync(request);

            if (response.ErrorReport != null && response.ErrorReport.ErrorItemCollection.FirstOrDefault().ErrorCode.GetHashCode() >= 400)
                return retorno.Set(response.ErrorReport.ErrorItemCollection.FirstOrDefault().ErrorCode, $"{response.ErrorReport.ErrorItemCollection.FirstOrDefault().ErrorCode} - {response.ErrorReport.ErrorItemCollection.FirstOrDefault().Description}");

            var loja = await RegistrarTransacao(lojaId);
            loja.Response.RegistroTransacaoStone = new Collection<RegistroTransacaoStone>();
            foreach (var item in response.CreditCardTransactionResultCollection)
            {
                loja.Response.RegistroTransacaoStone.Add(new RegistroTransacaoStone
                {
                    AuthorizationCode = item.AuthorizationCode,
                    AcquirerMessage = item.AcquirerMessage,
                    TransactionIdentifier = item.TransactionIdentifier,
                    TransactionKey = item.TransactionKey,
                    UniqueSequentialNumber = item.UniqueSequentialNumber,
                    OrderReference = response.OrderResult.OrderReference
                });
            }

            _dbContext.SaveChanges();
            retorno.Response = loja.Response;
            return retorno;
        }

        public async Task<HttpResult<Loja>> CreateTransactionCieloAsync(CieloRequest request, int lojaId)
        {
            var retorno = new HttpResult<Loja>();
            var response = await _serviceClient.TransacitonAsync(request);

            if (!sucessoCielo.Contains(response.Payment.ReturnCode))
                return retorno.Set(HttpStatusCode.BadRequest, $"Não foi possível efeturar a transação. Erro: {response.Payment.ReturnCode} - {response.Payment.ReturnMessage}");

            var loja = await RegistrarTransacao(lojaId);

            loja.Response.RegistroTransacaoCielo = new Collection<RegistroTransacaoCielo>();
            loja.Response.RegistroTransacaoCielo.Add(new RegistroTransacaoCielo
            {
                AuthorizationCode = response.Payment.AuthorizationCode,
                Tid = response.Payment.Tid,
                PaymentId = response.Payment.PaymentId,
                ProofOfSale = response.Payment.ProofOfSale,
                MerchantOrderId = response.MerchantOrderId
            });

            _dbContext.SaveChanges();
            retorno.Response = loja.Response;
            return retorno;
        }

        public async Task<HttpResult<Loja>> ObterLojaComCartao(int lojaId)
        {
            var response = new HttpResult<Loja>();

            var loja = await _lojaEntityService.ObterLojaComCartao(lojaId);
            if (loja == null) return response.SetHttpStatusToBadRequest("Loja não existe ou não cadastrada");

            response.Response = loja;
            return response;
        }

        // Implementatar na entidade caso dê tempo
        public bool ValidadarDadosDeEntrada(HttpResult<Loja> response, CreditCardBrandEnum bandeira)
        {
            if (bandeira.GetHashCode() > 2)
            {
                response.Set(HttpStatusCode.BadRequest, $"Trabalhamos somente com as bandeiras Visa e MasterCard");
                return false;
            }

            // * Validar Data de validade do cartao
            // * Validar Cartao de crédito

            return true;
        }

        private async Task<HttpResult<Loja>> RegistrarTransacao(int id) => await ObterLojaComCartao(id);
    }
}
