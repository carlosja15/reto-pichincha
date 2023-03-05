using Microsoft.EntityFrameworkCore;
using Reto.Domain.Entities;
using Reto.Infrastructure.Persistence.Configurations;

namespace Reto.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options)
		: base(options)
	{
	}

	public DbSet<Persona> Personas { get; set; }
	public DbSet<Cliente> Clientes { get; set; }
	public DbSet<Cuenta> Cuentas { get; set; }
	public DbSet<Movimiento> Movimientos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
		modelBuilder.ApplyConfiguration(new PersonaConfiguration());
		modelBuilder.ApplyConfiguration(new ClienteConfiguration());
		modelBuilder.ApplyConfiguration(new CuentaConfiguration());
		modelBuilder.ApplyConfiguration(new MovimientoConfiguration());
    }
}
