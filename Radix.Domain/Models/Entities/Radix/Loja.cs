using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Radix.Domain.Models.Entities.Radix
{
    public class Loja
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }
        public Collection<Cartao> Cartoes { get; set; }

        public Collection<RegistroTransacaoCielo> RegistroTransacaoCielo { get; set; }
        public Collection<RegistroTransacaoStone> RegistroTransacaoStone { get; set; }
    }
}
