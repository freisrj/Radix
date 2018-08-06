using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Radix.App.Messages
{
    [DataContract]
    public class CreditCardTransactionMessage
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        [DataMember(Name = "valor")]
        public long Valor { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [DataMember(Name = "parcelas")]
        [Range(1, 12, ErrorMessage = "Número de parcela inválida")]
        public int Parcelas { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(13, ErrorMessage = "Quantidade de caracteres excedido")]
        [MinLength(13, ErrorMessage = "Quantidade de caracteres faltando")]
        [DataMember(Name = "descricao")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [DataMember(Name = "cartaoCredito")]
        public CreditCardMessage CartaoCredito { get; set; }
    }
}
