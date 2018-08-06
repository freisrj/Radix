using Radix.Domain.Models.EnumTypes;
using System.ComponentModel.DataAnnotations;

namespace Radix.Domain.Models.Entities.Radix
{
    public class Cartao
    {
        [Key]
        public int Id { get; set; }

        public CreditCardBrandEnum Bandeira { get; set; }
        public AdquirenteEnum Adquirente { get; set; }
        public bool AntiFraude { get; set; }

        public int LojaId { get; set; }
        public Loja Loja { get; set; }
    }
}
