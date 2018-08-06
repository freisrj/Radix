using Radix.Domain.Models.Entities.Base;
using Radix.Domain.Models.EnumTypes;
using Radix.Infra.Cross.Helpers;
using System;
using System.Runtime.Serialization;

namespace Radix.Domain.Models.Entities.CreditCards
{
    [DataContract(Name = "CreditCardTransaction", Namespace = "")]
    public class CreditCardTransaction
    {
        [DataMember]
        public Guid Uid { get; set; }

        [DataMember]
        public CreditCard CreditCard { get; set; }

        [DataMember]
        public CreditCardTransactionOptions Options { get; set; }

        [DataMember]
        public long AmountInCents { get; set; }

        [DataMember]
        public int InstallmentCount { get; set; }

        #region CreditCardOperation

        [DataMember(Name = "CreditCardOperation", EmitDefaultValue = false)]
        private string CreditCardOperationField
        {
            get
            {
                if (this.CreditCardOperation == null) { return null; }
                return this.CreditCardOperation.ToString();
            }
            set
            {
                if (value == null)
                {
                    this.CreditCardOperationField = null;
                }
                else
                {
                    this.CreditCardOperation = (CreditCardOperationEnum)Enum.Parse(typeof(CreditCardOperationEnum), value);
                }
            }
        }

        [IgnoreDataMember]
        public CreditCardOperationEnum? CreditCardOperation { get; set; }

        #endregion

        [DataMember(EmitDefaultValue = false)]
        public string TransactionReference { get; set; }

        #region TransactionDateInMerchant

        [DataMember(Name = "TransactionDateInMerchant", EmitDefaultValue = false)]
        private string TransactionDateInMerchantField
        {
            get
            {
                if (this.TransactionDateInMerchant == null) { return null; }
                return this.TransactionDateInMerchant.Value.ToString(ServiceConstants.DATE_TIME_FORMAT);
            }
            set
            {
                if (value == null)
                {
                    this.TransactionDateInMerchant = null;
                }
                else
                {
                    this.TransactionDateInMerchant = DateTime.ParseExact(value, ServiceConstants.DATE_TIME_FORMAT, null);
                }
            }
        }

        public DateTime? TransactionDateInMerchant { get; set; }

        #endregion
    }
}
