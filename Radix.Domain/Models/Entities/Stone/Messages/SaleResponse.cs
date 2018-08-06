using System.Collections.ObjectModel;
using System.Net;
using System.Runtime.Serialization;

namespace Radix.Domain.Models.Entities.Messages
{
    [DataContract]
    public class SaleResponse
    {
        [DataMember]
        public Collection<CreditCardTransactionResultCollection> CreditCardTransactionResultCollection { get; set; }

        [DataMember]
        public OrderResult OrderResult { get; set; }

        [DataMember]
        public ErrorReport ErrorReport { get; set; }
        
    }

    [DataContract]
    public class CreditCardTransactionResultCollection
    {
        [DataMember]
        public string AuthorizationCode { get; set; }
        [DataMember]
        public string TransactionIdentifier { get; set; }
        [DataMember]
        public string TransactionKey { get; set; }
        [DataMember]
        public string UniqueSequentialNumber { get; set; }
        [DataMember]
        public string AcquirerMessage { get; set; }

    }

    [DataContract]
    public class OrderResult
    {
        [DataMember]
        public string OrderReference { get; set; }
    }

    [DataContract]
    public class ErrorReport
    {
        [DataMember]
        public Collection<ErrorItemCollection> ErrorItemCollection { get; set; }
    }

    [DataContract]
    public class ErrorItemCollection
    {
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public HttpStatusCode ErrorCode { get; set; }
    }
}
