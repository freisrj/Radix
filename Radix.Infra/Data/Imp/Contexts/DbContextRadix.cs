using Microsoft.EntityFrameworkCore;
using Radix.Domain.Models.Entities.Radix;
using Radix.Domain.Services.Contracts.Infra.Data.Contexts;
using Radix.Infra.Data.Imp.Mappings;

namespace Radix.Infra.Data.Imp.Contexts
{
    public class DbContextRadix : DbContext, IDbContextRadix
    {
        public DbContextRadix(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Loja> Loja { get; set; }

        public DbSet<Cartao> Cartao { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity(LojaMapConfig.ConfigureMap());
        }
    }
}
