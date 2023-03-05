using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reto.Domain.Entities;

namespace Reto.Infrastructure.Persistence.Configurations;

public class MovimientoConfiguration : IEntityTypeConfiguration<Movimiento>
{
    public void Configure(EntityTypeBuilder<Movimiento> builder)
    {
        builder.ToTable(nameof(Movimiento));
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Fecha).IsRequired();
        builder.Property(p => p.Tipo).IsRequired();
        builder.Property(p => p.Valor).IsRequired();
        builder.Property(p => p.Saldo).IsRequired();
    }
}
