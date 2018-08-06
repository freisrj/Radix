using Radix.Domain.Models.EnumTypes;

namespace Radix.Domain.Models.Entities.Cielo.CreditCards
{
    public class CreditCard
    {
        public string CardNumber { get; set; }
        public string Holder { get; set; }
        public string ExpirationDate { get; set; }
        public string SecurityCode { get; set; }
        public CreditCardBrandEnum Brand { get; set; }
    }
}
