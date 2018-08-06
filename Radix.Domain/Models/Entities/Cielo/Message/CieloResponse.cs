using System.Runtime.Serialization;

namespace Radix.Domain.Models.Entities.Cielo.Message
{
    [DataContract]
    public class CieloResponse
    {
        [DataMember]
        public string MerchantOrderId { get; set; }

        [DataMember]
        public PaymentMessage Payment { get; set; }
    }

    [DataContract]
    public class PaymentMessage
    {
        [DataMember]
        public string ProofOfSale { get; set; }

        [DataMember]
        public string Tid { get; set; }

        [DataMember]
        public string AuthorizationCode { get; set; }

        [DataMember]
        public string PaymentId { get; set; }

        [DataMember]
        public string ReturnMessage { get; set; }

        [DataMember]
        public string ReturnCode { get; set; }
    }
}
