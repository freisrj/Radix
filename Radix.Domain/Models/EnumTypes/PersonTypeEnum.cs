using System.Runtime.Serialization;

namespace Radix.Domain.Models.EnumTypes
{
    public enum PersonTypeEnum
    {
        [EnumMember]
        Person = 1,

        [EnumMember]
        Company = 2
    }
}
