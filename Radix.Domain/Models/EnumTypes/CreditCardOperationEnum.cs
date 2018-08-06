using System.Runtime.Serialization;

namespace Radix.Domain.Models.EnumTypes
{
    [DataContract]
    public enum CreditCardOperationEnum
    {
        [EnumMember]
        AuthOnly = 1,

        [EnumMember]
        AuthAndCapture = 2,

        [EnumMember]
        AuthAndCaptureWithDelay = 3,
    }
}
