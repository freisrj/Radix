using Radix.Domain.Models.EnumTypes;
using System;

namespace Radix.Domain.Models.Entities.Address
{
    public class BuyerAddress
    {

        public string Country { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string District { get; set; }

        public string Street { get; set; }

        public string Number { get; set; }

        public string Complement { get; set; }

        public string ZipCode { get; set; }

        #region AddressType

        private string AddressTypeField
        {
            get
            {
                return this.AddressType.ToString();
            }
            set
            {
                this.AddressType = (AddressTypeEnum)Enum.Parse(typeof(AddressTypeEnum), value);
            }
        }

        public AddressTypeEnum AddressType { get; set; }

        #endregion
    }
}
