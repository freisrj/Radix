using Radix.App.Messages;
using Radix.Domain.Models.Entities.Cielo.CreditCards;
using Radix.Domain.Models.Entities.Cielo.Customers;
using Radix.Domain.Models.Entities.Cielo.Message;
using Radix.Domain.Models.Entities.Cielo.Payments;
using Radix.Domain.Models.EnumTypes;
using System;
using System.Linq;

namespace Radix.App.Mapper
{
    public class MapToModelCielo
    {
        private static CreditCardBrandEnum bandeira;

        public static CieloRequest MapToModel(MessageRequest request, string orderId)
        {
            if (request == null) return new CieloRequest();

            bandeira = request.BandeiraCartao;

            return new CieloRequest
            {
                MerchantOrderId = orderId,
                Customer = MapToCustomer(request.Nome),
                Payment = MapToPayment(request.TransacaoCartaoCredito.FirstOrDefault())
            };
        }

        private static Customer MapToCustomer(string nome)
        {
            return new Customer() { Name = nome };
        }

        private static Payment MapToPayment(CreditCardTransactionMessage transacao)
        {
            return new Payment()
            {
                Amount = transacao.Valor,
                Installments = transacao.Parcelas,
                Type = "CreditCard",
                SoftDescriptor = transacao.Descricao,
                CreditCard = MapToCreditCard(transacao.CartaoCredito)
            };
        }

        private static CreditCard MapToCreditCard(CreditCardMessage cartao)
        {
            return new CreditCard()
            {
                Brand = bandeira,
                CardNumber = cartao.NumeroCartao,
                ExpirationDate = $"{cartao.MesExpiracao}/{cartao.AnoExpiracao}",
                Holder = cartao.NomeImpressoCartao,
                SecurityCode = cartao.CodigoSeguranca
            };
        }
    }
}
