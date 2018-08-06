using Radix.App.Messages;
using Radix.Domain.Models.Entities.Base;
using Radix.Domain.Models.Entities.CreditCards;
using Radix.Domain.Models.Entities.Messages;
using Radix.Domain.Models.Entities.Orders;
using Radix.Domain.Models.EnumTypes;
using System;
using System.Collections.ObjectModel;

namespace Radix.App.Mapper
{
    public class MapToModelStone
    {
        private static CreditCardBrandEnum bandeira;

        public static SaleRequest MapToModel(MessageRequest request, string orderId)
        {
            if (request == null) return new SaleRequest();

            bandeira = request.BandeiraCartao;

            return new SaleRequest
            {
                Order = MapToOrderStone(orderId),
                CreditCardTransactionCollection = MapToListCreditCardTransacionStone(request.TransacaoCartaoCredito)
            };
        }

        private static Order MapToOrderStone(string order)
        {
            return new Order() { OrderReference = order };
        }

        private static Collection<CreditCardTransaction> MapToListCreditCardTransacionStone(Collection<CreditCardTransactionMessage> transacoes)
        {
            var lista = new Collection<CreditCardTransaction>();

            foreach (var item in transacoes)
                lista.Add(MapToCreditCardTransacionStone(item));

            return lista;
        }

        private static CreditCardTransaction MapToCreditCardTransacionStone(CreditCardTransactionMessage transacao)
        {
            return new CreditCardTransaction()
            {
                AmountInCents = transacao.Valor,
                CreditCardOperation = CreditCardOperationEnum.AuthAndCapture,
                InstallmentCount = transacao.Parcelas,
                TransactionReference = "CreditCard",
                CreditCard = MapToCreditCardStone(transacao.CartaoCredito),
                Options = new CreditCardTransactionOptions() { CurrencyIso = CurrencyIsoEnum.BRL, PaymentMethodCode = 1}
            };
        }

        private static CreditCard MapToCreditCardStone(CreditCardMessage cartao)
        {
            return new CreditCard()
            {
               CreditCardBrand = bandeira,
               CreditCardNumber = cartao.NumeroCartao,
               ExpMonth = cartao.MesExpiracao,
               ExpYear = cartao.AnoExpiracao.Substring(2, 2),
               HolderName = cartao.NomeImpressoCartao,
               SecurityCode = cartao.CodigoSeguranca
            };
        }
    }
}
