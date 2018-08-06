using System.ComponentModel.DataAnnotations;

namespace Radix.Domain.Models.Entities.Radix
{
    public class RegistroTransacaoStone
    {
        [Key]
        public string OrderReference { get; set; }
        public string AcquirerMessage { get; set; }
        public string AuthorizationCode { get; set; }
        public string TransactionIdentifier { get; set; }
        public string TransactionKey { get; set; }
        public string UniqueSequentialNumber { get; set; }

        public Loja Loja { get; set; }
    }
}
