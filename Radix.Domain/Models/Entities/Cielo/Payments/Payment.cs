using Radix.Domain.Models.Entities.Cielo.CreditCards;

namespace Radix.Domain.Models.Entities.Cielo.Payments
{
    public class Payment
    {
        public string Type { get; set; }
        public double Amount { get; set; }
        public int Installments { get; set; }
        public string SoftDescriptor { get; set; }        
        public CreditCard CreditCard { get; set; }
    }
}
