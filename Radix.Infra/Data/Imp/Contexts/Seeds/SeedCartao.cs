using Radix.Domain.Models.Entities.Radix;
using Radix.Domain.Models.EnumTypes;
using System.Collections.Generic;
using System.Linq;

namespace Radix.Infra.Data.Imp.Contexts.Seeds
{
    public class SeedCartao
    {
        public static void InsertData(DbContextRadix context)
        {
            if (!context.Cartao.Any())
            {
                IList<Cartao> defaultCartao = new List<Cartao>();

                defaultCartao.Add(new Cartao { Bandeira = CreditCardBrandEnum.Visa, Adquirente = AdquirenteEnum.Cielo, LojaId = 1, AntiFraude = true });
                defaultCartao.Add(new Cartao { Bandeira = CreditCardBrandEnum.Mastercard, Adquirente = AdquirenteEnum.Stone, LojaId = 1, AntiFraude = true });
                defaultCartao.Add(new Cartao { Bandeira = CreditCardBrandEnum.Visa, Adquirente = AdquirenteEnum.Stone, LojaId = 2, AntiFraude = false });
                defaultCartao.Add(new Cartao { Bandeira = CreditCardBrandEnum.Visa, Adquirente = AdquirenteEnum.Cielo, LojaId = 3, AntiFraude = false });
                defaultCartao.Add(new Cartao { Bandeira = CreditCardBrandEnum.Mastercard, Adquirente = AdquirenteEnum.Stone, LojaId = 3, AntiFraude = false });
                defaultCartao.Add(new Cartao { Bandeira = CreditCardBrandEnum.Mastercard, Adquirente = AdquirenteEnum.Cielo, LojaId = 4, AntiFraude = true });

                foreach (var cartao in defaultCartao)
                    context.Cartao.Add(cartao);

                context.SaveChanges();
            }
        }
    }
}
