using Radix.Domain.Models.EnumTypes;
using System;
using System.ComponentModel.DataAnnotations;

namespace Radix.Domain.Models.Entities.Base
{
    public class CreditCard
    {
        [Key]
        public Guid InstantBuyKey { get; set; }
        
        public string CreditCardNumber { get; set; }
        
        public string HolderName { get; set; }
        
        public string SecurityCode { get; set; }
       
        public string ExpMonth { get; set; }
       
        public string ExpYear { get; set; }

        #region CreditCardBrand

        private string CreditCardBrandField
        {
            get
            {
                if (this.CreditCardBrand == null) { return null; }
                return this.CreditCardBrand.Value.ToString();
            }
            set
            {
                if (value == null)
                {
                    this.CreditCardBrand = null;
                }
                else
                {
                    CreditCardBrand = (CreditCardBrandEnum)Enum.Parse(typeof(CreditCardBrandEnum), value);
                }
            }
        }

        public CreditCardBrandEnum? CreditCardBrand { get; set; }

        #endregion
    }
}
