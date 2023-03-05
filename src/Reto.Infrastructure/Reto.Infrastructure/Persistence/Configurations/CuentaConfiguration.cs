using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reto.Domain.Entities;

namespace Reto.Infrastructure.Persistence.Configurations;

public class CuentaConfiguration : IEntityTypeConfiguration<Cuenta>
{
    public void Configure(EntityTypeBuilder<Cuenta> builder)
    {
        builder.ToTable(nameof(Cuenta));
        builder.HasKey(p => p.Id);
        builder.Property(p => p.NroCuenta).IsRequired();
        builder.Property(p => p.TipoCuenta).IsRequired();
        builder.Property(p => p.SaldoInicial).IsRequired();
        builder.Property(p => p.Estado).IsRequired();

        builder
            .HasOne(p => p.Cliente)
            .WithMany(p => p.Cuentas)
            .HasForeignKey(p => p.ClienteId);
    }
}
