using Radix.Domain.Models.Entities.Cielo.Customers;
using Radix.Domain.Models.Entities.Cielo.Payments;

namespace Radix.Domain.Models.Entities.Cielo.Message
{
    public class CieloRequest
    {
        public string MerchantOrderId { get; set; }
        public Customer Customer { get; set; }
        public Payment Payment { get; set; }
    }
}
