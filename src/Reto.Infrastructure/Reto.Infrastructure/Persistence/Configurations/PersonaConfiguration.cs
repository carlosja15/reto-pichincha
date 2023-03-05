using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reto.Domain.Entities;

namespace Reto.Infrastructure.Persistence.Configurations;

public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
{
    public void Configure(EntityTypeBuilder<Persona> builder)
    {
        builder.ToTable(nameof(Persona));
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).ValueGeneratedOnAdd().IsRequired();
        builder.Property(p => p.Nombre).IsRequired();
        builder.Property(p => p.Edad).IsRequired();
        builder.Property(p => p.Genero).IsRequired();
        builder.Property(p => p.Direccion).IsRequired();
        builder.Property(p => p.Telefono).IsRequired();
        builder.HasDiscriminator<string>("Categoria")
            .HasValue<Cliente>("Cliente");
    }
}
