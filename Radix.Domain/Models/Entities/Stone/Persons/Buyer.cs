using Radix.Domain.Models.Entities.Address;
using System;
using System.Collections.ObjectModel;

namespace Radix.Domain.Models.Entities.Persons
{
    public class Buyer : Person
    {
        public Guid BuyerKey { get; set; }

        public string BuyerReference { get; set; }

        public Collection<BuyerAddress> AddressCollection { get; set; }
    }
}
