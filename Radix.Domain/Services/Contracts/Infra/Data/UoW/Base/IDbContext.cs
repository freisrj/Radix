using System;

namespace Radix.Domain.Services.Contracts.Infra.Data.UoW.Base
{
    public interface IDbContext : IDisposable
    {
        int SaveChanges();
    }
}
