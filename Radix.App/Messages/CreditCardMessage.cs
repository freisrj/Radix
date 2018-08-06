using Radix.Domain.Models.EnumTypes;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Radix.App.Messages
{
    [DataContract]
    public class CreditCardMessage
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        [DataMember(Name = "numeroCartao")]
        public string NumeroCartao { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [DataMember(Name = "nomeImpressoCartao")]
        public string NomeImpressoCartao { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [DataMember(Name = "mesExpiracao")]
        [MaxLength(2, ErrorMessage = "Mes inválido")]
        [MinLength(2, ErrorMessage = "Mes inválido - Use 01, 02,...")]
        public string MesExpiracao { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [DataMember(Name = "anoExpiracao")]
        [MaxLength(4, ErrorMessage = "Mes inválido")]
        [MinLength(4, ErrorMessage = "Mes inválido - Use 2020, 2021,....")]
        public string AnoExpiracao { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [DataMember(Name = "codigoSeguranca")]
        public string CodigoSeguranca { get; set; }
    }
}
