using Radix.Domain.Models.Entities.Radix;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Radix.Infra.Data.Imp.Contexts.Seeds
{
    public class SeedLoja
    {
        public static void InsertData(DbContextRadix context)
        {
            if (!context.Loja.Any())
            {
                IList<Loja> defaultLoja = new List<Loja>();

                defaultLoja.Add(new Loja { Nome = "Loja A"});
                defaultLoja.Add(new Loja { Nome = "Loja B"});
                defaultLoja.Add(new Loja { Nome = "Loja C"});
                defaultLoja.Add(new Loja { Nome = "Loja D"});

                foreach (var loja in defaultLoja)
                    context.Loja.Add(loja);

                context.SaveChanges();
            }
        }
    }
}
