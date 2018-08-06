using System.Runtime.Serialization;

namespace Radix.Domain.Models.EnumTypes
{
    public enum DocumentTypeEnum
    {
        [EnumMember]
        CPF = 1,

        [EnumMember]
        CNPJ = 2
    }
}
