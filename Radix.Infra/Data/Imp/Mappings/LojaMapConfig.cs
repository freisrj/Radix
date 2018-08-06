using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Radix.Domain.Models.Entities.Radix;
using System;

namespace Radix.Infra.Data.Imp.Mappings
{
    internal static class LojaMapConfig
    {
        internal static Action<EntityTypeBuilder<Loja>> ConfigureMap() => (entity) =>
        {
            entity.Property(ti => ti.Nome)
            .IsRequired()
            .HasMaxLength(50);
        };
    }
}
