using Microsoft.EntityFrameworkCore;
using Radix.Domain.Models.Entities.Radix;
using Radix.Domain.Services.Contracts.Infra.Data.UoW.Base;

namespace Radix.Domain.Services.Contracts.Infra.Data.Contexts
{
    public interface IDbContextRadix : IDbContext
    {
        DbSet<Loja> Loja { get; }
        DbSet<Cartao> Cartao { get; }
    }
}
