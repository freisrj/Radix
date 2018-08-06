using Radix.Domain.Models.EnumTypes;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Radix.App.Messages
{
    [DataContract]
    public class MessageRequest
    {
        [DataMember(Name = "lojaId")]
        [Required (ErrorMessage = "Campo obrigatório")]
        [Range(1,int.MaxValue, ErrorMessage = "Identificaçõ da loja inválida")]
        public int LojaId { get; set; }

        [DataMember(Name = "bandeiraCartao")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public CreditCardBrandEnum BandeiraCartao { get; set; }

        [DataMember(Name = "nome")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Nome { get; set; }

        [DataMember(Name = "transacaoCartaoCredito")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public Collection<CreditCardTransactionMessage> TransacaoCartaoCredito { get; set; }
    }
}
