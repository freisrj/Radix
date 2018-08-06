using System.ComponentModel.DataAnnotations;

namespace Radix.Domain.Models.Entities.Radix
{
    public class RegistroTransacaoCielo
    {
        [Key]
        public string MerchantOrderId { get; set; }
        public string ProofOfSale { get; set; }
        public string Tid { get; set; }
        public string AuthorizationCode { get; set; }
        public string PaymentId { get; set; }

        public Loja Loja { get; set; }
        
    }
}
