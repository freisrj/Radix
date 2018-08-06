using Radix.Domain.Models.Entities.Cielo.CreditCards;
using Radix.Domain.Models.Entities.Cielo.Customers;
using Radix.Domain.Models.Entities.Cielo.Message;
using Radix.Domain.Models.Entities.Cielo.Payments;
using Radix.Domain.Models.EnumTypes;

namespace Radix.Tests.ModelTests
{
    public class Models
    {
        public static CieloResponse CieloResponse()
        {
            return new CieloResponse
            {
                MerchantOrderId = "00000001",

                Payment = new PaymentMessage
                {
                    AuthorizationCode = "1234",
                    PaymentId = "0000",
                    ProofOfSale = "000000",
                    ReturnCode = "57",
                    ReturnMessage = "Não autorizado",
                    Tid = "00000"
                }
            };
        }

        public static CieloRequest CieloRequest()
        {
            return new CieloRequest
            {
               Customer = new Customer {Name = "Ned Stark"},
               MerchantOrderId = "12345678",
               Payment = new Payment {
                   Amount = 12000,
                   Installments = 1,
                   SoftDescriptor = "UUUYUYUY",
                   Type = "",
                   CreditCard = new CreditCard {
                       Brand = CreditCardBrandEnum.Visa,
                       CardNumber = "78787878787878",
                       ExpirationDate = "07/2019",
                       Holder = "Ned Stark"
                   }
               }
            };
        }
    }
}
