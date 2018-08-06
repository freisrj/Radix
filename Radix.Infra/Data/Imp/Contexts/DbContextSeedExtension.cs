using Radix.Infra.Data.Imp.Contexts.Seeds;

namespace Radix.Infra.Data.Imp.Contexts
{
    public static class DbContextSeedExtension
    {
        public static void EnsureSeeded(this DbContextRadix context)
        {
            SeedLoja.InsertData(context);
            SeedCartao.InsertData(context);
            
        }
    }
}
