using Radix.Domain.Models.Entities.CreditCards;
using Radix.Domain.Models.Entities.Orders;
using Radix.Domain.Models.Entities.Persons;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace Radix.Domain.Models.Entities.Messages
{
    public class SaleRequest
    {

        [DataMember(EmitDefaultValue = false)]
        public Collection<CreditCardTransaction> CreditCardTransactionCollection { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public Buyer Buyer { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public Order Order { get; set; }


    }
}
