using Radix.Domain.Models.EnumTypes;
using Radix.Infra.Cross.Helpers;
using System;

namespace Radix.Domain.Models.Entities.Persons
{
    public class Person
    {

        public string Name { get; set; }

        public PersonTypeEnum PersonType { get; set; }
        
        public string DocumentNumber { get; set; }

        public DocumentTypeEnum DocumentType { get; set; }
       
        public GenderEnum? Gender { get; set; }

        #region Birthdate

        private string BirthdateField
        {
            get
            {
                if (this.Birthdate == null) { return null; }
                return this.Birthdate.Value.ToString(ServiceConstants.DATE_TIME_FORMAT);
            }
            set
            {
                if (value == null)
                {
                    this.Birthdate = null;
                }
                else
                {
                    this.Birthdate = DateTime.ParseExact(value, ServiceConstants.DATE_TIME_FORMAT, null);
                }
            }
        }

        public DateTime? Birthdate { get; set; }

        #endregion

        public string Email { get; set; }

        #region EmailType

        private string EmailTypeField
        {
            get
            {
                return this.EmailType.ToString();
            }
            set
            {
                this.EmailType = (EmailTypeEnum)Enum.Parse(typeof(EmailTypeEnum), value);
            }
        }

        public EmailTypeEnum EmailType { get; set; }

        #endregion

        public string MobilePhone { get; set; }

        public string HomePhone { get; set; }

        public string WorkPhone { get; set; }
    }
}
