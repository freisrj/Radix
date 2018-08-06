using System.Runtime.Serialization;

namespace Radix.Domain.Models.Entities.Orders
{
    [DataContract(Name = "Order", Namespace = "")]
    public class Order
    {
        [DataMember(EmitDefaultValue = false)]
        public string OrderReference { get; set; }
    }
}
